using _4Tables2._0.Domain.Base.Repository;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;

namespace _4Tables2._0.Domain.OrderContext.Order.Interfaces.Repository
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        Task<OrderEntity> GetOrderById(long id);
        Task<OrderEntity> GetOrderByIdWithIncludes(long id);
        Task<OrderEntity> GetOrderByTableIdActive(int tableId);
        Task<OrderEntity> GetOrderByTableIdWithIncludes(int tableId);

        void AddReceivedOrder(ReceivedOrderEntity receivedOrder);

    }
}
