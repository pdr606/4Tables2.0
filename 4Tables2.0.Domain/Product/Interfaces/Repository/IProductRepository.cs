using _4Tables2._0.Domain.Base.Repository;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;

namespace _4Tables2._0.Domain.ProductDomain.Interfaces.Repository
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task AddRangeAsync(List<ProductEntity> products);
        Task<string> FindProductByIdAndReturnProductName(long id);
        Task<ProductEntity> FindByName(string name);
        Task<bool> ActiveDesactive(long id);
        Task<IEnumerable<ProductEntity>> FindAllDesactives();
        Task<IEnumerable<ProductEntity>> FindAllActives();
        Task<IEnumerable<ProductEntity>> FindAllByCategory(EProductCategory category);
    }
}
