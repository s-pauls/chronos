using Chronos.Core;
using Chronos.Data;
using Chronos.Data.EntityFramework;
using Chronos.Data.EntityFramework.Repositories;
using Chronos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chronos.Core.Microsoft.AzureDevOps;
using Chronos.Core.RequestsOfWork;

namespace Chronos.App.Configurations
{
    public static class ChronosCoreDependencies
    {
        public static IServiceCollection AddChronosCore(this IServiceCollection services)
        {
            services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IFeatureRulesRepository, FeatureRulesRepository>()
                .AddScoped<IFeatureRulesService, FeatureRulesService>()
                .AddScoped<IRequestOfWorkRepository, RequestOfWorkRepository>()
                .AddScoped<IRequestOfWorkService, RequestOfWorkService>()
                .AddScoped<IAuditLogRepository, AuditLogRepository>()
                .AddScoped<IAuditLogService, AuditLogService>()
                .AddScoped<IWorkItemService, WorkItemService>()
                .AddScoped<IAzureWorkItemClient, AzureWorkItemClient>();

            services.AddHttpClient<IUserService, UserService>();

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
