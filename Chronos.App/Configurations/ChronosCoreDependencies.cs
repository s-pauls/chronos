using Chronos.Core;
using Chronos.Data;
using Chronos.Data.EntityFramework;
using Chronos.Data.EntityFramework.Repositories;
using Chronos.Domain;
using Chronos.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Chronos.App.Configurations
{
    public static class ChronosCoreDependencies
    {
        public static IServiceCollection AddChronosCore(this IServiceCollection services)
        {
            services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IAuditLogRepository, AuditLogRepository>();

            return services;
        }
    }
}
