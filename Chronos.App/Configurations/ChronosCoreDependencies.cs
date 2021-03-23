using Chronos.Core;
using Chronos.Data;
using Chronos.Data.EntityFramework;
using Chronos.Data.EntityFramework.Repositories;
using Chronos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
                .AddScoped<IAuditLogRepository, AuditLogRepository>()
                .AddScoped<IWorkItemService, WorkItemService>();

            return services;
        }

        public static IServiceCollection AddChronosDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChronosDbConnection");
            services.AddDbContext<ChronosDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
