using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.ProductDomain.Dto;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Services
{
    public interface IProductService
    {
        Task<Result> AddProductInRangeAsync(List<ProductRequestDTO> productsDto);
        Task<Result> ActiveOrDesativeProduct(long id);
        Task<Result> GetAllProductsActivesAsync();
        Task<Result> GetAllProductsDesactivesAsync();
        Task<Result> GetAllProductsByCategoryAsync(EProductCategory category);
        Task<string> GetProductNameById(long id);
        
    }
}
