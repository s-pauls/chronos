namespace Chronos.App.DataContracts.Blank
{
    public class BlankTask
    {
        public int? ParentStoryId { get; set; }
        
        public string Name { get; set; }

        public decimal OriginalEstimate { get; set; }

        public string Activity { get; set; }
    }
}
