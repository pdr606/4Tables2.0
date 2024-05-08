using _4Tables2._0.Domain.Base.Factories;
using _4Tables2._0.Domain.OrderContext.Order.DTO;
using _4Tables2._0.Domain.OrderContext.Order.Entity;

namespace _4Tables2._0.Application.Common
{
    public static partial class EntityMapper
    {

        public static OrderResponseDTO ToOrderDTO(OrderEntity entity)
        {
            return new OrderResponseDTO(entity.Id,
                                        entity.Created_At.ToString("dd/MM/yyyy HH:mm:ss"),
                                        entity.TableNumber,
                                        entity.Total.ToString("N2").Replace('.', ','),
                                        entity.ReceivedOrders.SelectMany(x => x.ProductOrders.Select(ToProductOrderDto)));
        }
    }
}
