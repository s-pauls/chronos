using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class EstimateEntityItemEntityConfiguration : IEntityTypeConfiguration<EstimateItemEntity>
    {
        public void Configure(EntityTypeBuilder<EstimateItemEntity> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();
        }
    }
}
