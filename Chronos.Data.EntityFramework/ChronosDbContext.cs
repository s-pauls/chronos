using Chronos.Data.EntityFramework.Entities;
using Chronos.Data.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EntityFramework
{
    public class ChronosDbContext : DbContext
    {
        public ChronosDbContext(DbContextOptions<ChronosDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<FeatureRulesEntity> FeatureRules { get; set; }
        public DbSet<AuditLogEntity> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditLogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureRulesEntityConfiguration());
        }
    }
}
