namespace Chronos.Domain.Entities
{
    public class EstimateTask
    {
        public string Title { get; set; }
        public bool ConsolidateHours { get; set; }
        public decimal Hours { get; set; }
        public string Activity { get; set; }
    }
}
