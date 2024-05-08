using _4Tables2._0.Application.Common;
using _4Tables2._0.Domain.Base.Messages;
using _4Tables2._0.Domain.Base.Result;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Repository;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Services;
using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;

namespace _4Tables2._0.Application.Settings.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;
        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<Result> AddSettingsAsync(short totalTables)
        {
            var settings = await _settingsRepository.GetSettingsAsync();

            if (settings == null)
            {
                _settingsRepository.AddSettings(SettingsEntity.Create(totalTables));
            }
            else
            {
                var totalTablesActive = await _settingsRepository.GetAllTablesAsync();

                if (totalTables < totalTablesActive.Count)
                {
                    var tablesToRemove = totalTablesActive.OrderByDescending(x => x.Id)
                                                          .Take(totalTablesActive.Count - totalTables)
                                                          .ToList();

                    _settingsRepository.RemoveTables(tablesToRemove);
                }
                else if (totalTables > totalTablesActive.Count)
                {
                    var tablesToCreate = totalTables - totalTablesActive.Count;
                    var maxId = totalTablesActive.Max(table => table.Id);
                    var newTables = TableEntity.CreateIncrement(tablesToCreate, maxId, settings.Id);

                    _settingsRepository.AddTables(newTables);

                }

                return Result.Create(200, DefaultMessage.PropertieCreateWithSuccessfully(), true);
            }

            return Result.Create(200, DefaultMessage.PropertyAtualizateSuccessfully("Settings", "TotalTables", totalTables), true);
        }

        public async Task DesactiveTable(int tableId)
        {
            await _settingsRepository.DesactiveTable(tableId);
        }

        public async Task<Result> GetAllTablesAsyncNoTracking()
        {
            var tables = await _settingsRepository.GetAllTablesAsyncNoTracking();

            return Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true).SetData(tables.Select(EntityMapper.ToTableDto));
        }

        public async Task<Result> GetSettings()
        {
            var settings = await _settingsRepository.GetSettingsAsync();

            return settings == null ? Result.Create(404, DefaultMessage.PropertieNotFoundInSytem("Settings"), false)
                                    :  Result.Create(200, DefaultMessage.SearchCompletedSuccessfully(), true)
                                             .SetData(EntityMapper.ToSettingsDto(settings));
        }
    }
}
