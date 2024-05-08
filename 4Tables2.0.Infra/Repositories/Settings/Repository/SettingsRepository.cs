using _4Tables2._0.Application.Base.Repository;
using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Repository;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;
using _4Tables2._0.Infra.Data.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.Repositories.Settings.Repository
{
    public class SettingsRepository : BaseRepository<SettingsEntity>, ISettingsRepository
    {
        public SettingsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<SettingsEntity> GetSettingsAsync()
        {
            return await _dbSet.Include(x => x.Tables)
                               .FirstOrDefaultAsync();
        }

        public void AddSettings(SettingsEntity settingsEntity)
        {
            _dbSet.Add(settingsEntity);
            _db.SaveChanges();
        }

        public async Task DesactiveTable(int tabledId)
        {
            var table = await _db.Set<TableEntity>().FirstOrDefaultAsync(x => x.Id == tabledId);

            if (table != null)
            {
                table.IsAvailable(false);
                _db.Set<TableEntity>().Entry(table).State = EntityState.Modified;
            }
        }

        public async Task<List<TableEntity>> GetAllTablesAsync()
        {
            return await _db.Set<TableEntity>()
                            .ToListAsync();
        }

        public async Task<IEnumerable<TableEntity>> GetAllTablesAsyncNoTracking()
        {
            return await _db.Set<TableEntity>().AsNoTracking()
                                               .ToListAsync();
        }

        public void AddTables(List<TableEntity> tables)
        {
            _db.Set<TableEntity>().AddRange(tables);
            _db.SaveChanges();
        }

        public void RemoveTables(List<TableEntity> tablesToRemove)
        {
            _db.Set<TableEntity>().RemoveRange(tablesToRemove);
            _db.SaveChanges();
        }
    }
}
