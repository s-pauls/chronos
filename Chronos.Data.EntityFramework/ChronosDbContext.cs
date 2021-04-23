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

        public DbSet<FeatureRulesEntity> FeatureRules { get; set; }
        public DbSet<FeatureBlankEntity> FeatureBlank { get; set; }
        public DbSet<RequestOfWorkEntity> RequestsOfWork { get; set; }
        public DbSet<EstimateTemplateEntity> EstimateTemplates{ get; set; }
        public DbSet<EstimateEntity> Estimates{ get; set; }
        public DbSet<EstimateItemEntity> EstimateItems{ get; set; }
        public DbSet<EstimateItemTaskEntity> EstimateItemTasks{ get; set; }
        public DbSet<EstimateMemberEntity> EstimateMembers{ get; set; }
        public DbSet<AuditLogEntity> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditLogEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureRulesEntityConfiguration());

            modelBuilder.ApplyConfiguration(new RequestOfWorkEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StatementOfWorkEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FixRequestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureDefinitionDocumentEntityConfiguration());

            modelBuilder.ApplyConfiguration(new EstimateTemplateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EstimateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EstimateEntityItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EstimateEntityItemTaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EstimateMemberEntityConfiguration());
        }
    }
}
