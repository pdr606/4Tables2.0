using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Application.Common
{
    public static partial class EntityMapper
    {
        public static ProductEntity ProductToEntity(ProductRequestDTO dto)
        {
            decimal.TryParse(dto.price.Replace(',', '.'), out decimal price);

            return ProductEntity.Create(dto.name.ToUpper(),
                                  price,
                                  dto.category);
        }

        public static ProductResponseDto ProductToDto(ProductEntity entity)
        {
            return ProductResponseDto.Create(entity.Id,
                                             entity.Name,
                                             entity.Price.ToString("N2").Replace('.', ','),
                                             entity.TotalRequests,
                                             entity.Category);
        }
    }
}
