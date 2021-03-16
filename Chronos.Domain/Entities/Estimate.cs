using System;

namespace Chronos.Domain.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public Feature Feature { get; set; }
        public Version Version { get; set; }
        public int FeatureDefinitionDocumentUrl { get; set; }
        public int DesignDocumentUrl { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
