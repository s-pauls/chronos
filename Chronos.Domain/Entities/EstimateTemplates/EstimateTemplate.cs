using System.Collections.Generic;

namespace Chronos.Domain.Entities.EstimateTemplates
{
    public class EstimateTemplate
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Version { get; set; }

        public HashSet<EstimateTemplateTask> Tasks { get; set; } 

        public HashSet<EstimateTemplateGeneralValue> GeneralValues { get; set; } 

        public HashSet<EstimateTemplateItem> Items { get; set; } 
    }
}
