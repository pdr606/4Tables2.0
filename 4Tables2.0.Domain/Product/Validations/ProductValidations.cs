using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.Base.Validate;
using _4Tables2._0.Domain.ProductDomain.Entity;

namespace _4Tables2._0.Domain.Product.Validations
{
    public class ProductValidations : IValidate
    {
        private readonly ProductEntity _product;
        public ProductValidations(ProductEntity product)
        {
            _product = product;
        }

        public ProductValidations MinPriceValue()
        {
            if (_product.Price < 0)
                _product.PullNotification(
                    Notifcation.Create(
                        "Price", "Valor não deve ser menor que 0"));

            return 
                this;
        }

        public bool IsValid()
        {
            return 
                _product.Notifcations.Count == 0 ? true : false;
        }
    }
}
