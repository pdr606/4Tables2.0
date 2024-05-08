﻿using _4Tables2._0.Application.Common;
using _4Tables2._0.Domain.Base.Messages;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Repository;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Services;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Dto;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Services;
using _4Tables2._0.Infra.Repositories.OrderContext.Order.Repository;

namespace _4Tables2._0.Application.OrderContext.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ISettingsService _settingsService;

        public OrderService(IOrderRepository orderRepository,
                            IProductService productService,
                            ISettingsService settingsService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _settingsService = settingsService;
        }

        public async Task<Result> GellOrderByIdWithIncludesAsync(long id)
        {
            var order = await _orderRepository.GetOrderByIdWithIncludes(id);

            if (order == null) 
                return Result.Create(404, DefaultMessage.SearchByPropertyNotFound("ORDER", id), false);

            order.AggregateOrderProducts();
            order.CalculateTotal();

            return Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(EntityMapper.ToOrderDTO(order));
        }

        public async Task<Result> GetOrderByTableIdWithIncludesAsync(int tabledId)
        {
            var order = await _orderRepository.GetOrderByTableIdWithIncludes(tabledId);

            if (order == null) 
                return Result.Create(404, DefaultMessage.SearchByPropertyNotFound("ORDER", tabledId), false);

            order.AggregateOrderProducts();
            order.CalculateTotal();

            return Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(EntityMapper.ToOrderDTO(order));
        }

        public async Task<Result> AddReceivedOrderAsync(ReceivedOrderRequestDTO dto)
        {
            ReceivedOrderEntity receivedOrder;
            var order = await _orderRepository.GetOrderByTableIdActive(dto.tableNumber);

            if (order != null)
            {
                if (!order.OrderTableIsEqualReceivedOrderTable(dto.tableNumber)) 
                    return Result.Create(404, DefaultMessage.TableNumberAndOrderNotEquals(), false);

                receivedOrder = ReceivedOrderEntity.Create(dto.observation, dto.tableNumber)
                                                                  .PullOrder(order)
                                                                  .PullProductOrder(await LoopToCreateProductOrderByDTO(dto.products));
            }
            else
            {
                receivedOrder = ReceivedOrderEntity.Create(dto.observation, dto.tableNumber)
                                                              .PullOrder(OrderEntity.Create(dto.tableNumber))
                                                              .PullProductOrder(await LoopToCreateProductOrderByDTO(dto.products));

                await _settingsService.DesactiveTable(receivedOrder.Table);
                 
            }

            _orderRepository.AddReceivedOrder(receivedOrder);

            return Result.Create(200, DefaultMessage.PropertiesCreateWithSuccessfully(), true)
                         .SetData(EntityMapper.ToSimpleOrderDto(receivedOrder));
        }

        private async Task<List<ProductOrderEntity>> LoopToCreateProductOrderByDTO(List<ProductOrderRequestDto> productOrders)
        {
            List<ProductOrderEntity> productOrdersList = new();

            foreach (var productOrderDTO in productOrders)
            {
                var productName = await _productService.GetProductNameById(productOrderDTO.productId);
                if (productName != null)
                    productOrdersList.Add(ProductOrderEntity.Create(productOrderDTO.productId, productOrderDTO.quantity, productName));
            }

            return productOrdersList;
        }
    }
}
