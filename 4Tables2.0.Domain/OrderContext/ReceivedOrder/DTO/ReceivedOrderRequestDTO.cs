using _4Tables2._0.Domain.OrderContext.ProductOrder.Dto;

namespace _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO
{
    public record ReceivedOrderRequestDTO(short tableNumber,
                                          string observation,
                                          List<ProductOrderRequestDto> products
                                              );
}
