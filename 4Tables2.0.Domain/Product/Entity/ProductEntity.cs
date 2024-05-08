using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.Base.Validate;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.Product.Validations;
using _4Tables2._0.Domain.ProductDomain.Enum;
using _4Tables2._0.Domain.Base.Interfaces;

namespace _4Tables2._0.Domain.ProductDomain.Entity
{
    public class ProductEntity : BaseEntity, IValidate , IAgreggateRoot
    {

        private ProductEntity(string name,
                        decimal price,
                        EProductCategory category)
        {
            Name = name;
            Price = price;
            Category = category;
            TotalRequests = 0;
        }

        protected ProductEntity() { }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int TotalRequests { get; private set; }
        public EProductCategory Category { get; private set; }
        public IReadOnlyCollection<ProductOrderEntity> ProductOrders;

        public static ProductEntity Create(string name,
                              decimal price,
                              EProductCategory category)
        {
            return new ProductEntity(name, price, category);
        }

        public bool IsValid()
        {
            return
                new ProductValidations(this).MinPriceValue().IsValid();
        }
    }
}
