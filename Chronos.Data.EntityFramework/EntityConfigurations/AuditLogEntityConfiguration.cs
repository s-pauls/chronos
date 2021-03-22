using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class AuditLogEntityConfiguration : IEntityTypeConfiguration<AuditLogEntity>
    {
        public void Configure(EntityTypeBuilder<AuditLogEntity> builder)
        {
            builder.HasIndex(t => t.Date);

            builder.HasIndex(t => t.UserId);

            builder.HasIndex(t => new { t.ObjectId, t.ObjectType });

            builder
                .Property(t => t.Message)
                .IsRequired();
        }
    }
}
