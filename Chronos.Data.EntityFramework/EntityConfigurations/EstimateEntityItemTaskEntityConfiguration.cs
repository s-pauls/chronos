using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class EstimateEntityItemTaskEntityConfiguration : IEntityTypeConfiguration<EstimateItemTaskEntity>
    {
        public void Configure(EntityTypeBuilder<EstimateItemTaskEntity> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();
        }
    }
}
