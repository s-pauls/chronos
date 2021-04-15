using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class FeatureRulesEntityConfiguration : IEntityTypeConfiguration<FeatureRulesEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureRulesEntity> builder)
        {
            builder
                .Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
