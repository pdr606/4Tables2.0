using _4Tables2._0.Domain.SettingsContext.Table.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class TableConfig : IEntityTypeConfiguration<TableEntity>
    {
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
