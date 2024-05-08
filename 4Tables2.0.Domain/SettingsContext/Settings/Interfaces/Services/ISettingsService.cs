using _4Tables2._0.Domain.Base.Result;

namespace _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Services
{
    public interface ISettingsService
    {
        Task<Result> AddSettingsAsync(short totalTables);
        Task<Result> GetSettings();
        Task<Result> GetAllTablesAsyncNoTracking();
        Task DesactiveTable(int tableId);
    }
}
