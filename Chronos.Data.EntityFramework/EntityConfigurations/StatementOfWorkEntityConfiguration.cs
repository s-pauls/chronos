using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class StatementOfWorkEntityConfiguration : IEntityTypeConfiguration<StatementOfWorkEntity>
    {
        public void Configure(EntityTypeBuilder<StatementOfWorkEntity> builder)
        {
            builder.ToTable("RequestOfWork_SOW");

            builder
                .Property(t => t.PartnerNumber)
                .HasMaxLength(50);
        }
    }
}
