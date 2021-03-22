using System;
using System.Collections.Generic;
using Chronos.Domain.Entities.Features;

namespace Chronos.Domain.Entities
{
    public class Estimate
    {
        public int Id { get; set; }
        public Feature Feature { get; set; }
        public Version Version { get; set; }
        public Uri FeatureDefinitionDocumentUrl { get; set; }
        public Uri DesignDocumentUrl { get; set; }
        public decimal GrandTotal { get; set; }
        List<EstimateStory> Stories{ get; set; }
    }
}
