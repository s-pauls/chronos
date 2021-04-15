using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class RequestOfWorkEntityConfiguration : IEntityTypeConfiguration<RequestOfWorkEntity>
    {
        public void Configure(EntityTypeBuilder<RequestOfWorkEntity> builder)
        {
            builder.ToTable("RequestOfWork");

            builder
                .Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();

            builder
                .Property(t => t.NumberPrefix)
                .HasMaxLength(10)
                .IsRequired();

            builder
                .HasIndex(t => new { t.Number, t.NumberSuffix })
                .IsUnique();

            builder
                .Property(t => t.NumberSuffix)
                .HasMaxLength(10);

            builder
                .Property(t => t.ProductId)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(t => t.SkypeGroupUrl)
                .HasMaxLength(450);

            builder
                .Property(t => t.DocumentUrl)
                .HasMaxLength(450);
        }
    }
}
