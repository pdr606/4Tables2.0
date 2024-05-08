using _4Tables2._0.Domain.Base.Repository;
using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;

namespace _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Repository
{
    public interface ISettingsRepository : IBaseRepository<SettingsEntity>
    {
        Task<List<TableEntity>> GetAllTablesAsync();
        Task<SettingsEntity> GetSettingsAsync();
        Task<IEnumerable<TableEntity>> GetAllTablesAsyncNoTracking();
        Task DesactiveTable(int tabledId);
        void AddSettings(SettingsEntity settingsEntity);
        void AddTables(List<TableEntity> tables);
        void RemoveTables(List<TableEntity> tablesToRemove);
    }
}
