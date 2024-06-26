using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.OrderContext.Order.DTO;

public record OrderStatsDTO
{
    public decimal TotalSalesToday { get; init; }       
    public decimal AverageSalesToday { get; init; }    
    public decimal MaxOrderTotal { get; init; }         
    public decimal MinOrderTotal { get; init; }         
    public decimal TotalProductsSold { get; init; }     
    public decimal TotalOrders { get; init; }          
    public decimal MostPopularTable { get; init; }      
    public decimal LeastPopularTable { get; init; }     
    public EProductCategory MostSoldCategory { get; set; }     
}