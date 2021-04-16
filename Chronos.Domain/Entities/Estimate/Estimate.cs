using System;
using System.Collections.Generic;

namespace Chronos.Domain.Entities.Estimate
{
    public class Estimate
    {
        public int Id { get; set; }
        public int RequestOfWorkId { get; set; }
        public Version Version { get; set; }
        public int EstimateTemplateId { get; set; }
        public Uri FeatureDefinitionDocumentUrl { get; set; }
        public Uri DesignDocumentUrl { get; set; }
        public double GrandTotal { get; set; }
        public List<EstimateItem> EstimateItems{ get; set; }
    }
}
