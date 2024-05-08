using _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;

namespace _4Tables2._0.Application.Common
{
    public static partial class EntityMapper
    {

        public static ReceivedOrderResponseDTO ToSimpleOrderDto(ReceivedOrderEntity entity)
        {

            return
                new ReceivedOrderResponseDTO(entity.Table,
                                             entity.OrderId,
                                             entity.Observation,
                                             entity.Created_At.ToString("dd/MM/yyyy HH:mm:ss"),
                                             entity.ProductOrders.Select(ToProductOrderDto)
                                             );
        }
    }
}
