using _4Tables2._0.Domain.Base.Entity;

namespace _4Tables2._0.Domain.SettingsContext.Table.Entity
{
    public class TableEntity : BaseEntity
    {

        private TableEntity(int tableId)
        {
            Id = tableId;
        }

        protected TableEntity() { }

        public int Id { get; private set; }
        public int SettingsEntityId { get; private set; }

        public static List<TableEntity> Create(int totalTables)
        {
            var listTables = new List<TableEntity>();

            for (short i = 1; i < totalTables; i++)
            {
                listTables.Add(new TableEntity(i));
            }

            return listTables;
        }

        public static List<TableEntity> CreateIncrement(int totalTables, int maxId, int settingsId)
        {
            var listTables = new List<TableEntity>();

            for (short i = 1; i <= totalTables; i++)
            {
                var newTable = new TableEntity(maxId + i).PullSettingsId(settingsId);
                listTables.Add(newTable);
            }

            return listTables;
        }

        private TableEntity PullSettingsId(int settingsId)
        {
            SettingsEntityId = settingsId; return this;
        }
    }
}
