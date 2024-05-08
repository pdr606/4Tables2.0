using _4Tables2._0.Domain.OrderContext.ProductOrder.DTO;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;

namespace _4Tables2._0.Application.Common
{
    public static partial class EntityMapper
    {

        public static ProductOrderResponseDTO ToProductOrderDto(ProductOrderEntity entity)
        {
            return
                new ProductOrderResponseDTO(entity.ProductId,
                                            entity.ProductName,
                                            entity.Quantity);
        }
    }
}
