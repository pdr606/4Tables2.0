using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.OrderContext.Order.DTO;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Repository;
using _4Tables2._0.Domain.OrderContext.ProductOrder.DTO;
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

        public async Task<OrderResponseDTO> GetOrderByIdWithIncludes(long orderId)
        {
            var order = await _dbSet.AsNoTracking()
                                    .Where(x => x.Available && x.Id == orderId)
                                    .Select(x => new
                                    {
                                        x.Id,
                                        x.Created_At,
                                        x.TableNumber,
                                        x.Total,
                                        GroupedProductOrders = x.ReceivedOrders
                                            .SelectMany(ro => ro.ProductOrders)
                                            .GroupBy(po => new { po.ProductId, po.Product.Name })
                                            .Select(g => new
                                            {
                                                g.Key.ProductId,
                                                ProductName = g.Key.Name,
                                                TotalQuantity = (short)g.Sum(po => po.Quantity)
                                            })
                                            .ToList()
                                    })
                                    .FirstOrDefaultAsync();

            if (order == null) return null;

            return new OrderResponseDTO(
                order.Id,
                order.Created_At.ToString("dd/MM/yyyy"),
                order.TableNumber,
                order.Total.ToString("N2"),
                order.GroupedProductOrders.Select(x => new ProductOrderResponseDTO(
                    x.ProductId,
                    x.ProductName,
                    x.TotalQuantity
                )).ToList()
            );
        }

        public async Task<OrderResponseDTO> GetOrderByTableIdWithIncludes(int tableId)
        {
            var order = await _dbSet.AsNoTracking()
                                    .Where(x => x.Available && x.TableNumber == tableId)
                                    .Select(x => new
                                    {
                                        x.Id,
                                        x.Created_At,
                                        x.TableNumber,
                                        x.Total,
                                        GroupedProductOrders = x.ReceivedOrders
                                            .SelectMany(ro => ro.ProductOrders)
                                            .GroupBy(po => new { po.ProductId, po.Product.Name })
                                            .Select(g => new
                                            {
                                                g.Key.ProductId,
                                                ProductName = g.Key.Name,
                                                TotalQuantity = (short)g.Sum(po => po.Quantity)
                                            })
                                            .ToList()
                                    })
                                    .FirstOrDefaultAsync();

            if (order == null) return null;

            return new OrderResponseDTO(
                order.Id,
                order.Created_At.ToString("dd/MM/yyyy"),
                order.TableNumber,
                order.Total.ToString("N2"),
                order.GroupedProductOrders.Select(x => new ProductOrderResponseDTO(
                    x.ProductId,
                    x.ProductName,
                    x.TotalQuantity
                )).ToList()
            );
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
