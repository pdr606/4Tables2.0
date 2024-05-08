﻿using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.Base.Interfaces;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;
using System.Net;

namespace _4Tables2._0.Domain.OrderContext.Order.Entity
{
    public class OrderEntity : BaseEntity, IAgreggateRoot
    {
        public OrderEntity(short tableNumber)
        {
            TableNumber = tableNumber;
        }

        protected OrderEntity() { }

        private List<ReceivedOrderEntity> _receveidOrders = new();

        public long Id { get; private set; }
        public decimal Total { get; private set; } = 0;
        public int TableNumber { get; private set; }
        public TableEntity Table { get; private set; }
        public IReadOnlyCollection<ReceivedOrderEntity> ReceivedOrders => _receveidOrders;

        public static OrderEntity Create(short tableNumber)
        {
            return new OrderEntity(tableNumber);
        }

        public OrderEntity PullReceivedOrder(ReceivedOrderEntity simpleOrder)
        {
            _receveidOrders.Add(simpleOrder); return this;
        }

        public void AggregateOrderProducts()
        {
            var aggregatedProductOrders = new Dictionary<long, ProductOrderEntity>();

            foreach (var receivedOrder in ReceivedOrders)
            {
                foreach (var productOrder in receivedOrder.ProductOrders)
                {
                    if (aggregatedProductOrders.ContainsKey(productOrder.ProductId))
                    {
                        var existingProductOrder = aggregatedProductOrders[productOrder.ProductId];
                        existingProductOrder.IncrementQuantity(productOrder.Quantity);
                    }
                    else
                    {
                        aggregatedProductOrders.Add(productOrder.ProductId, productOrder);
                    }
                }
            }

            _receveidOrders.Clear();

            foreach (var productOrder in aggregatedProductOrders.Values)
            {
                var receivedOrder = ReceivedOrderEntity.Create(null, productOrder.ReceivedOrder.Table);
                receivedOrder.PullOrder(this);
                receivedOrder.PullProductOrder(new List<ProductOrderEntity> { productOrder });
                _receveidOrders.Add(receivedOrder);
            }
        }

        public void CalculateTotal()
        {
            var total = 0.00M;

            foreach (var receivedOrder in ReceivedOrders)
            {
                foreach (var productOrder in receivedOrder.ProductOrders)
                {
                    total += productOrder.Quantity * productOrder.Product.Price;
                }
            }

            this.Total = total;
        }

        public bool OrderTableIsEqualReceivedOrderTable(short receivedOrderTable)
        {
            return this.TableNumber.Equals(receivedOrderTable);
        }
    }
}
