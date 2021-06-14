using Chronos.Domain.Enums;

namespace Chronos.App.DataContracts.EstimateTemplates
{
    public class EstimateTemplateItem
    {
        public string Name { get; set; }
        public Discipline Discipline { get; set; }
        public string  Value { get; set; }
        public EstimateTemplateItemType ValueType { get; set; }
        public string TaskName { get; set; }
    }
}
