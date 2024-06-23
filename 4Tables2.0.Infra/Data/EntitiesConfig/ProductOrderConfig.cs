using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.ProductDomain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4Tables2._0.Infra.Data.EntitiesConfig
{
    public class ProductOrderConfig : IEntityTypeConfiguration<ProductOrderEntity>
    {
        public void Configure(EntityTypeBuilder<ProductOrderEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.ProductId);

            builder.Ignore(x => x._productPrice);

        }
    }
}
