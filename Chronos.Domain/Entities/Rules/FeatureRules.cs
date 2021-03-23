namespace Chronos.Domain.Entities.Rules
{
    public class FeatureRules
    {
        public StoryRules ZeroStoryRules { get; set; }

        public TaskRules ZeroTaskRules { get; set; }

        public TaskRules FeatureTaskRules { get; set; }

        public StoryRules StoryRules { get; set; }
        
        public TaskRules TaskRules { get; set; }
    }
}
