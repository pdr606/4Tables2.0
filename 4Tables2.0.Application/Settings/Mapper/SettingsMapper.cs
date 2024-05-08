
using _4Tables2._0.Domain.SettingsContext.Settings.DTO;
using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.DTO;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;

namespace _4Tables2._0.Application.Common
{
    public static partial class EntityMapper
    {
        public static SettingsDto ToSettingsDto(SettingsEntity settings)
        {
            return new SettingsDto(settings.isWaiterFee);
        }

        public static TableResultDTO ToTableDto(TableEntity tableEntity)
        {
            return new TableResultDTO(tableEntity.Id, tableEntity.Available);
        }
    }
}
