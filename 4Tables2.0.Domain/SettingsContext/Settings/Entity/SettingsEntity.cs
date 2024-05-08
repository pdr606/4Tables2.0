using _4Tables2._0.Domain.Base.Entity;
using _4Tables2._0.Domain.Base.Interfaces;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;

namespace _4Tables2._0.Domain.SettingsContext.Settings.Entity
{
    public class SettingsEntity : BaseEntity, IAgreggateRoot
    {
        public SettingsEntity(short tables)
        {
            _tables.AddRange(TableEntity.Create(tables));
            isWaiterFee = true;
        }

        protected SettingsEntity() { }

        private List<TableEntity> _tables = new();

        public int Id { get; private set; }
        public bool isWaiterFee { get; private set; }
        public IReadOnlyCollection<TableEntity> Tables => _tables;

        public static SettingsEntity Create(short tables)
        {
            return new SettingsEntity(tables);
        }

        public SettingsEntity ActiveDesactiveWaiterFee(bool active)
        {
            isWaiterFee = active; return this;
        }
    }
}
