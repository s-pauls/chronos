using Chronos.App.Configurations;
using Chronos.Data.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Chronos.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateDbContext<ChronosDbContext>()
                .CreateDbIfNotExists()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
