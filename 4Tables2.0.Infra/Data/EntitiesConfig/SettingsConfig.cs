using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class SettingsConfig : IEntityTypeConfiguration<SettingsEntity>
    {
        public void Configure(EntityTypeBuilder<SettingsEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Tables)
                   .WithOne();
        }
    }
}
