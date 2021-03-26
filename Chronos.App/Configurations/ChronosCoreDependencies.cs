using Chronos.Core;
using Chronos.Data;
using Chronos.Data.EntityFramework;
using Chronos.Data.EntityFramework.Repositories;
using Chronos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chronos.Core.Microsoft.AzureDevOps;

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
                .AddScoped<IWorkItemService, WorkItemService>()
                .AddScoped<IAzureWorkItemClient, AzureWorkItemClient>();

            return services;
        }

        public static IServiceCollection AddChronosDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ChronosDbConnection");
            services.AddDbContext<ChronosDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddHttpClient<IUserService, UserService>();

            return services;
        }
    }
}
