using _4Tables2._0.Domain.OrderContext.ProductOrder.DTO;

namespace _4Tables2._0.Domain.OrderContext.ReceivedOrder.DTO
{
    public record ReceivedOrderResponseDTO(int table,
                                           long orderId,
                                           string? observation,
                                           string createdAt,
                                           IEnumerable<ProductOrderResponseDTO> productOrders);
}
