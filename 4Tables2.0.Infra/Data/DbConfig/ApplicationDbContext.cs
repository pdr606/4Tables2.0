
using _4Tables2._0.Domain.Base.Common;
using _4Tables2._0.Domain.OrderContext.Order.Entity;
using _4Tables2._0.Domain.OrderContext.ProductOrder.Entity;
using _4Tables2._0.Domain.OrderContext.ReceivedOrder.Entity;
using _4Tables2._0.Domain.ProductDomain.Entity;
using _4Tables2._0.Domain.SettingsContext.Settings.Entity;
using _4Tables2._0.Domain.SettingsContext.Table.Entity;
using _4Tables2._0.Infra.Data.EntitiesConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4Tables2._0.Infra.Data.DbConfig
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(ApplicationDbContext).Assembly;

            modelBuilder.Ignore<Notifcation>();

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        DbSet<ProductEntity> Products { get; set; }
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<SettingsEntity> Settings { get; set; }
        DbSet<ReceivedOrderEntity> ReceivedOrders { get; set; }
        DbSet<ProductOrderEntity> ProductOrders { get; set; }
        DbSet<TableEntity> Tables { get; set; }
    }
}
