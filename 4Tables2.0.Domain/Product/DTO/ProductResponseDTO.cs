using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Dto
{
    public record ProductResponseDto
    {

        private ProductResponseDto(long id,
                                   string name,
                                   string price,
                                   int totalRequests,
                                   EProductCategory category)
        {
            Id = id;
            Name = name;
            Price = price;
            TotalRequests = totalRequests;
            Category = category;
        }

        public long Id { get;}
        public string Name { get; }
        public string Price { get; }
        public int TotalRequests { get; }
        public EProductCategory Category { get; }

        public static ProductResponseDto Create(long id,
                                              string name,
                                              string price,
                                              int totalRequests,
                                              EProductCategory category)
        {
            return new ProductResponseDto(id, name, price, totalRequests, category);
        }
    }
}
