using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.Base.Interfaces;
using _4Tables2._0.Domain.Base.Repository;
using _4Tables2._0.Infra.Data.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Application.Base.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity , IAgreggateRoot
    {
        protected readonly ApplicationDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
             _db.Set<TEntity>()
                .AddAsync(entity);

            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _db.Set<TEntity>()
                            .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyncNoTracking()
        {
            return await _db.Set<TEntity>()
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>()
                .Entry(entity).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }
    }
}
