using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class EstimateTemplateEntityConfiguration : IEntityTypeConfiguration<EstimateTemplateEntity>
    {
        public void Configure(EntityTypeBuilder<EstimateTemplateEntity> builder)
        {
            builder
                .Property(t => t.Value)
                .IsRequired();

            builder
                .Property(t => t.Version)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
