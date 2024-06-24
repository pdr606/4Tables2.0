using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO;

namespace _4Tables2._0.Domain.OrderContext.Order.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Result> AddReceivedOrderAsync(ReceivedOrderRequestDTO dto);
        Task<Result> GellOrderByIdWithIncludesAsync(long id);
        Task<Result> GetOrderByTableIdWithIncludesAsync(int tabledId);
        Task<Result> GetAllOrdersActives();
        Task<Result> GetOrderStats(DateTime dataInicial, DateTime dataFinal);
    }
}
