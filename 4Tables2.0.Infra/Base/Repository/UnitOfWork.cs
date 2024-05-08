using _4Tables2._0.Infra.Base.Interfaces;
using _4Tables2._0.Infra.Data.DbConfig;

namespace _4Tables2._0.Infra.Base.Repository
{
    public sealed class UnitOfWork : IUnitOfWork 
    {

        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
