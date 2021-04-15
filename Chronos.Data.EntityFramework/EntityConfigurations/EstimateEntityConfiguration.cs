using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class EstimateEntityConfiguration : IEntityTypeConfiguration<EstimateEntity>
    {
        public void Configure(EntityTypeBuilder<EstimateEntity> builder)
        {
            builder
                .Property(t => t.Version)
                .HasMaxLength(10)
                .IsRequired();


        }
    }
}
