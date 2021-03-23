using System.Text;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Entities.Blank;
using Chronos.Domain.Entities.Features;

namespace Chronos.Core
{
    public class TitleComposer
    {
        private const string FeatureCode = "[CSD/CSP#]";
        private const string ProductCode = "[Product]";
        private const string StoryOrderNumber = "[StoryOrderNumber]";
        private const string StoryName = "[StoryName]";
        private const string TaskName = "[TaskName]";
        private const string StoryId = "[StoryId]";
        private const string TaskOrderNumber = "[TaskOrderNumber]";
        
        public string ComposeStoryTitle(string titleTemplate, Feature feature, BlankStory blankStory)
        {
            return new StringBuilder(titleTemplate)
                .Replace(FeatureCode, feature.FeatureCode)
                .Replace(ProductCode, feature.Product.Name)
                .Replace(StoryOrderNumber, blankStory.OrderNumber.ToString())
                .Replace(StoryName, blankStory.Name)
                .ToString();
        }

        public string ComposeTaskTitle(string titleTemplate,
            Feature feature,
            BlankTask blankTask,
            int taskOrderNumber,
            BlankStory blankStory = null,
            AzureStory azureStory = null)
        {
            return new StringBuilder(titleTemplate)
                .Replace(FeatureCode, feature.FeatureCode)
                .Replace(ProductCode, feature.Product.Name)
                .Replace(StoryId, azureStory?.Id.ToString() ?? "")
                .Replace(StoryOrderNumber, blankStory?.OrderNumber.ToString() ?? "")
                .Replace(TaskOrderNumber, taskOrderNumber.ToString())
                .Replace(TaskName, blankTask.Name)
                .ToString();
        }
    }
}
