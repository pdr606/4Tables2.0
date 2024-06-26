using _4Tables.Base;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Services;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO;
using _4Tables2._0.Domain.User.Enum;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("Table/{tableId:int}")]
        public async Task<ActionResult> GetOrderByTableIdAsync([FromRoute] int tableId)
        {
            var result = await _orderService.GetOrderByTableIdWithIncludesAsync(tableId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllOrdersActive()
        {
            var result = await _orderService.GetAllOrdersActives();

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("Stats")]
        [Authorize(Roles = nameof(EUserRole.Admin))]
        public async Task<ActionResult> GetOrderStats([FromQuery] DateTime dataInicial, [FromQuery] DateTime dataFinal)
        {
            var result = await _orderService.GetOrderStats(dataInicial, dataFinal);
            return Ok(result);
        }
    }
}
