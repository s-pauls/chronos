using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class EstimateMemberEntityConfiguration : IEntityTypeConfiguration<EstimateMemberEntity>
    {
        public void Configure(EntityTypeBuilder<EstimateMemberEntity> builder)
        {
            builder
                .Property(t => t.MemberId)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(t => new { t.MemberId, t.EstimateId })
                .IsUnique();
        }
    }
}
