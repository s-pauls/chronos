using System.Collections.Generic;

namespace Chronos.App.DataContracts.EstimateTemplates
{
    public class EstimateTemplate
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public List<EstimateTemplateTask> Tasks { get; set; }

        public List<EstimateTemplateGeneralValue> GeneralValues { get; set; }

        public List<EstimateTemplateItem> Items { get; set; }
    }
}
