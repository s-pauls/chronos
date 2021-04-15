using System;
using System.Collections.Generic;
using Chronos.Domain.Entities.Features;
using Chronos.Domain.Entities.RequestsOfWork;

namespace Chronos.Domain.Entities.Estimate
{
    public class Estimate
    {
        public int Id { get; set; }
        public RequestOfWork RequestOfWork { get; set; }
        public Version Version { get; set; }
        public Uri FeatureDefinitionDocumentUrl { get; set; }
        public Uri DesignDocumentUrl { get; set; }
        public decimal GrandTotal { get; set; }
        List<EstimateStory> Stories{ get; set; }
    }
}
