using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class FeatureDefinitionDocumentEntityConfiguration : IEntityTypeConfiguration<FeatureDefinitionDocumentEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureDefinitionDocumentEntity> builder)
        {
            builder.ToTable("RequestOfWork_FDD");

        }
    }
}
