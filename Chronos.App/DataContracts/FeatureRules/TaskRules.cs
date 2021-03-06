namespace Chronos.App.DataContracts.FeatureRules
{
    public class TaskRules
    {
        public string Title { get; set; }
        public TitleVariable[] TitleVariables { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public string[] DefaultTags { get; set; }
    }
}
