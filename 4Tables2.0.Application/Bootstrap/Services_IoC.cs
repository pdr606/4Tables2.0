using _4Tables2._0.Application.Authorization.Service;
using _4Tables2._0.Application.OrderContext.Order.Services;
using _4Tables2._0.Application.ProductDomain.Services;
using _4Tables2._0.Application.Settings.Services;
using _4Tables2._0.Domain.Authorization.Interfaces;
using _4Tables2._0.Domain.OrderContext.Order.Interfaces.Services;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using _4Tables2._0.Domain.SettingsContext.Settings.Interfaces.Services;
using _4Tables2._0.Infra.Base.Interfaces;
using _4Tables2._0.Infra.Base.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace _4Tables2._0.IoC.Bootstrap
{
    public static class Services_IoC
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
