using Chronos.Domain.Entities.Products;

namespace Chronos.Domain.Entities.Features
{
    public class Feature
    {
        public int AdoId { get; set; }
        public string FeatureCode { get; set; }
        public Product Product { get; set; }
    }
}
