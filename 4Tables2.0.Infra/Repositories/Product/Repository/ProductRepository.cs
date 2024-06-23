using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.ProductDomain.Enum;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Repository;
using _4Tables2._0.Infra.Data.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.Repositories.Product.Repository
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task AddRangeAsync(List<ProductEntity> products)
        {
            await _dbSet.AddRangeAsync(products);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductEntity> FindByName(string name)
        {
            return await _dbSet.AsNoTracking()
                               .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> ActiveDesactive(long id)
        {
            var product = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.IsAvailable(!product.Available);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ProductEntity>> FindAllDesactives()
        {
            return await _dbSet.Where(x => !x.Available)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> FindAllActives()
        {
            return await _dbSet.Where(x => x.Available)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>> FindAllByCategory(EProductCategory category)
        {
            return await _dbSet.Where(x => x.Category == category)
                               .AsNoTracking()
                               .ToListAsync();
        }

        public async Task<(string productName, decimal productPrice)> FindProductByIdAndReturnProductName(long id)
        {
            var query = await _dbSet.AsNoTracking()
                            .Where(x => x.Id == id)
                            .Select(x => new
                            {
                                x.Name,
                                x.Price
                            })
                            .FirstOrDefaultAsync();

            return (query.Name, query.Price);
        }
    }
}
