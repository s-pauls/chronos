using Chronos.Core;
using Chronos.Core.Estimates;
using Chronos.Core.EstimateTemplates;
using Chronos.Data;
using Chronos.Data.EntityFramework;
using Chronos.Data.EntityFramework.Repositories;
using Chronos.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chronos.Core.Microsoft.AzureDevOps;
using Chronos.Core.RequestsOfWork;
using Chronos.Core.Excel.Parsers;
using Chronos.Domain.Settings;
using Microsoft.Extensions.Options;
using Organization.WebApi.Client.Extensions;

namespace Chronos.App.Configurations
{
    public static class ChronosCoreDependencies
    {
        public static IServiceCollection AddChronosCore(this IServiceCollection services)
        {
            services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IFeatureRulesRepository, FeatureRulesRepository>()
                .AddScoped<IFeatureRulesService, FeatureRulesService>()
                .AddScoped<IRequestOfWorkRepository, RequestOfWorkRepository>()
                .AddScoped<IRequestOfWorkService, RequestOfWorkService>()
                .AddScoped<IAuditLogRepository, AuditLogRepository>()
                .AddScoped<IAuditLogService, AuditLogService>()
                .AddScoped<IWorkItemService, WorkItemService>()
                .AddScoped<IAzureWorkItemClient, AzureWorkItemClient>()
                .AddScoped<IMembersService, MembersService>()
                .AddScoped<IEstimateRepository, EstimateRepository>()
                .AddScoped<IEstimateService, EstimateService>()
                .AddScoped<IEstimateParser, PointSolutionsEstimateParser>()
                .AddScoped<IEstimateTemplateRepository, EstimateTemplateRepository>()
                .AddScoped<IEstimateTemplateService, EstimateTemplateService>();

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

        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServicesSettings>(configuration.GetSection("ServiceURLs"));

            return services;
        }

        public static IServiceCollection AddOrganizationClients(this IServiceCollection services)
        {
            services.AddOrganizationClient((serviceProvider, httpClient) =>
            {
                var servicesSettings = serviceProvider.GetService<IOptions<ServicesSettings>>().Value;
                httpClient.BaseAddress = servicesSettings.Organization;
            });

            return services;
        }

    }
}
