using Chronos.Domain.Enums;

namespace Chronos.App.DataContracts.EstimateTemplates
{
    public class EstimateTemplateTask
    {
        public string TaskName { get; set; }
        public string  Activity { get; set; }
        public TaskLevel TaskLevel { get; set; }
    }
}
