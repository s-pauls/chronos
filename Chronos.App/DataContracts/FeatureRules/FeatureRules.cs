namespace Chronos.App.DataContracts.FeatureRules
{
    public class FeatureRules
    {
        public string Name { get; set; }
        public TaskRules FeatureTaskRules { get; set; }
        public StoryRules ZeroStoryRules { get; set; }
        public TaskRules ZeroTaskRules { get; set; }
        public StoryRules StoryRules { get; set; }
        public TaskRules TaskRules { get; set; }
    }
}
