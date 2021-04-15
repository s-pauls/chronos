using Chronos.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chronos.Data.EntityFramework.EntityConfigurations
{
    internal class FeatureBlankEntityConfiguration : IEntityTypeConfiguration<FeatureBlankEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureBlankEntity> builder)
        {
        }
    }
}
