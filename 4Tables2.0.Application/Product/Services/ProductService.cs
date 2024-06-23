using _4Tables2._0.Application.Common;
using _4Tables2._0.Application.Common.Base;
using _4Tables2._0.Domain.Base.Messages;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using _4Tables2._0.Infra.Base.Interfaces;

namespace _4Tables2._0.Application.ProductDomain.Services
{
    public class ProductService : BaseService, IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productRepository = productRepository;
        }

        #region public methods

        public async Task<Result> ActiveOrDesativeProduct(long id)
        {
            try
            {
                var succes = await _productRepository.ActiveDesactive(id);

                if (!succes)
                    return
                        Result.Create(404, DefaultMessage.SearchByPropertyNotFound("Produto", id), true);
                else
                    return
                        Result.Create(200, DefaultMessage.PropertyAtualizateSuccessfully("Produto", "ID", id), false);

            }
            catch (Exception ex)
            {
                return
                    Result.Create(500, DefaultMessage.InternalError(ex.Message), false);
            }
        }

        public async Task<Result> AddProductInRangeAsync(List<ProductRequestDTO> productsDto)
        {
            try
            {
                var products = await RemoveDuplicateProducts(productsDto);
                (var invalidProducts, var validProducts) = SeparateInvalidAndValidProducts(products);

                if (validProducts.Count > 0)
                    await _productRepository.AddRangeAsync(validProducts);

                if (invalidProducts.Count > 0)
                    return
                        Result.Create(400, DefaultMessage.InvalidItens(), false)
                              .SetData(invalidProducts);

                return
                    Result.Create(200, DefaultMessage.PropertiesCreateWithSuccessfully(), true);

            }
            catch (Exception ex)
            {
                return
                    Result.Create(500, DefaultMessage.InternalError(ex.Message), false);
            }
        }

        public async Task<Result> GetAllProductsActivesAsync()
        {
            try
            {
                var products = await _productRepository.FindAllActives();

                return
                    Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(products.Select(EntityMapper.ProductToDto));
            }
            catch (Exception ex)
            {
                return
                    Result.Create(500, DefaultMessage.InternalError(ex.Message), false);
            }
        }

        public async Task<Result> GetAllProductsByCategoryAsync(EProductCategory category)
        {
            try
            {
                if (!Enum.IsDefined(typeof(EProductCategory), category))
                {
                    return
                        Result.Create(404, DefaultMessage.PropertieNotFoundInSytem("Categoria"), true);
                }

                var products = await _productRepository.FindAllByCategory(category);

                return
                    Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(products.Select(EntityMapper.ProductToDto));

            }
            catch (Exception ex)
            {
                return
                    Result.Create(500, DefaultMessage.InternalError(ex.Message), false);
            }
        }

        public async Task<Result> GetAllProductsDesactivesAsync()
        {
            try
            {
                var products = await _productRepository.FindAllDesactives();

                return
                    Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(products.Select(EntityMapper.ProductToDto));

            }
            catch (Exception ex)
            {
                return
                    Result.Create(500, DefaultMessage.InternalError(ex.Message), false);
            }
        }

        public async Task<(string productName, decimal productPrice)> GetProductNameById(long id)
        {
            return
                await _productRepository.FindProductByIdAndReturnProductName(id);
        }

        #endregion  

        #region private methods

        private (List<Result>, List<ProductEntity>) SeparateInvalidAndValidProducts(List<ProductEntity> products)
        {
            List<Result> invalidProducts = new();
            List<ProductEntity> validProducts = new();

            foreach (var product in products)
            {
                if (!product.IsValid())
                    invalidProducts.Add(Result.Create(400, $"Produto com NOME {product.Name} não criado.", false).SetData(product.Notifcations));
                else
                    validProducts.Add(product);
            }

            return (invalidProducts, validProducts);
        }

        private async Task<List<ProductEntity>> RemoveDuplicateProducts(List<ProductRequestDTO> productsDto)
        {
            var products = new List<ProductEntity>();

            foreach (var productDto in productsDto)
            {
                var product = await _productRepository.FindByName(productDto.name.ToUpper());

                if (product == null)
                    products.Add(EntityMapper.ProductToEntity(productDto));
            }
            return
                products;
        }

        #endregion
    }
}
