using System;
using System.Text;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Entities.Blank;
using Chronos.Domain.Entities.FeatureRules;
using Chronos.Domain.Entities.Features;

namespace Chronos.Core
{
    public class TitleComposer
    {
        public string ComposeStoryTitle(string titleTemplate, Feature feature, BlankStory blankStory)
        {
            return new StringBuilder(titleTemplate)
                .Replace(FeatureRulesConstants.TitleVariables.FeatureCode, feature.FeatureCode)
                .Replace(FeatureRulesConstants.TitleVariables.ProductCode, feature.Product.Name)
                .Replace(FeatureRulesConstants.TitleVariables.StoryOrderNumber, blankStory.OrderNumber.ToString())
                .Replace(FeatureRulesConstants.TitleVariables.StoryName, blankStory.Name)
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
                .Replace(FeatureRulesConstants.TitleVariables.FeatureCode, feature.FeatureCode)
                .Replace(FeatureRulesConstants.TitleVariables.ProductCode, feature.Product.Name)
                .Replace(FeatureRulesConstants.TitleVariables.StoryId, azureStory?.Id.ToString() ?? "")
                .Replace(FeatureRulesConstants.TitleVariables.StoryOrderNumber, blankStory?.OrderNumber.ToString() ?? "")
                .Replace(FeatureRulesConstants.TitleVariables.TaskOrderNumber, taskOrderNumber.ToString())
                .Replace(FeatureRulesConstants.TitleVariables.TaskName, blankTask.Name)
                .ToString();
        }

        public string ComposeTag(string titleTag,
            Feature feature)
        {
            return new StringBuilder(titleTag)
                .Replace(FeatureRulesConstants.TagVariables.Product, feature.Product.Name)
                .Replace(FeatureRulesConstants.TagVariables.Year, new DateTime().Year.ToString())
                .Replace(FeatureRulesConstants.TagVariables.Team, "") // todo
                .ToString();
        }
    }
}
