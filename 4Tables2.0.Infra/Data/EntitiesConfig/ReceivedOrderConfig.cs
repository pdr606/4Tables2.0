using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class ReceivedOrderConfig : IEntityTypeConfiguration<ReceivedOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ReceivedOrderEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Observation).IsRequired(false);

            builder.HasMany(x => x.ProductOrders)
                   .WithOne(x => x.ReceivedOrder)
                   .HasForeignKey(x => x.SimpleOrderId)
                   .IsRequired();
        }
    }
}
