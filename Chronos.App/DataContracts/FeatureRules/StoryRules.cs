namespace Chronos.App.DataContracts.FeatureRules
{
    public class StoryRules
    {
        public string Title { get; set; }
        public TitleVariable[] TitleVariables { get; set; }
        public string Description { get; set; }
        public string AcceptanceCriteria { get; set; }
        public string[] Tags { get; set; }
        public string[] DefaultTags { get; set; }
    }
}
