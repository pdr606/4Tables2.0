using _4Tables2._0.Domain.OrderContext.Order.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class OrderConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total)
                   .IsRequired()
                   .HasPrecision(8, 2);


            builder.HasMany(x => x.ReceivedOrders)
                    .WithOne(x => x.Order)
                    .HasForeignKey(x => x.OrderId)
                    .IsRequired();

            builder.HasOne(x => x.Table)
                   .WithMany()
                   .HasForeignKey(x => x.TableNumber);
        }
    }
}
