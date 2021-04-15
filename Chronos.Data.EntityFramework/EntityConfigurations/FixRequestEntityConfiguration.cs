using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class FixRequestEntityConfiguration : IEntityTypeConfiguration<FixRequestEntity>
    {
        public void Configure(EntityTypeBuilder<FixRequestEntity> builder)
        {
            builder.ToTable("RequestOfWork_FR");

            builder
                .Property(t => t.WexTeam)
                .HasMaxLength(450);

        }
    }
}
