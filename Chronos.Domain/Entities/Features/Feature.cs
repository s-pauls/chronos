using Chronos.Domain.Entities.Products;

namespace Chronos.Domain.Entities.Features
{
    public class Feature
    {
        public int Id { get; set; }

        public string FeatureCode { get; set; }

        public int ExternalId { get; set; }

        public Release Release { get; set; }

        public Product Product { get; set; }
    }
}
