using _4Tables.Base;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Services;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.ControllerOrder.Order
{
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(ReceivedOrderRequestDTO dto)
        {
            var result = await _orderService.AddReceivedOrderAsync(dto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{orderId:long}")]
        public async Task<ActionResult> GetOrderByIdAsync([FromRoute] long orderId)
        {
            var result = await _orderService.GellOrderByIdWithIncludesAsync(orderId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("table/{tableId:int}")]
        public async Task<ActionResult> GetOrderByTableIdAsync([FromRoute] int tableId)
        {
            var result = await _orderService.GetOrderByTableIdWithIncludesAsync(tableId);

            return StatusCode(result.StatusCode, result);
        }
    }
}
