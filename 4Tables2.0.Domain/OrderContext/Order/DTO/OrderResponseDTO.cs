using _4Tables2._0.Domain.OrderContext.ProductOrder.DTO;
using _4Tables2._0.Domain.ProductDomain.Dto;

namespace _4Tables2._0.Domain.OrderContext.Order.DTO
{
    public record OrderResponseDTO(long id,
                                    string createdAt,
                                    int table,
                                    string total,
                                    IEnumerable<ProductOrderResponseDTO> products);
}
