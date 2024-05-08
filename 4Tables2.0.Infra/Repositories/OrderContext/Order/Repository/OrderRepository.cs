using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Repository;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Infra.Data.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.Repositories.OrderContext.Order.Repository
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void AddReceivedOrder(ReceivedOrderEntity receivedOrder)
        {
            _db.Set<ReceivedOrderEntity>().Add(receivedOrder);
            _db.SaveChanges();
        }

        public async Task<OrderEntity> GetOrderByIdWithIncludes(long id)
        {
            return await _dbSet.AsNoTracking()
                                .Include(x => x.ReceivedOrders)
                                    .ThenInclude(x => x.ProductOrders)
                                    .ThenInclude(x => x.Product)
                                .Where(x => x.Available && x.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<OrderEntity> GetOrderByTableIdWithIncludes(int tableId)
        {
            return await _dbSet.AsNoTracking()
                                .Where(x => x.Available && x.TableNumber == tableId)
                                .Include(x => x.ReceivedOrders)
                                    .ThenInclude(x => x.ProductOrders)
                                    .ThenInclude(x => x.Product)
                                    .FirstOrDefaultAsync();
        }

        public async Task<OrderEntity> GetOrderById(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
            
        public async Task<OrderEntity> GetOrderByTableIdActive(int tableId)
        {
            return await _dbSet.Where(x => x.TableNumber == tableId
                                      &&
                                      x.Available)
                               .FirstOrDefaultAsync();
        }
    }
}
