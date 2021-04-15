using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Entities.Blank;
using Chronos.Domain.Entities.FeatureRules;
using Chronos.Domain.Entities.Features;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IAzureWorkItemClient _client;

        public WorkItemService(IAzureWorkItemClient client)
        {
            _client = client;
        }

        public async Task CreateWorkItemsAsync(BlankFeature blankFeature, FeatureRules featureRules, AzureSettings settings)
        {
            // get from Database
            var internalFeature = new Feature();

            var azureFeature = await _client.GetAzureWorkItemAsync(internalFeature.AdoId, settings);

            var tasks = new List<Task>();

            if (blankFeature.Tasks != null)
            {
                var taskOrderNumber = 1;

                foreach (var blankTask in blankFeature.Tasks)
                {
                    tasks.Add(CreateFeatureTaskAsync(internalFeature, blankTask, featureRules.FeatureTaskRules, taskOrderNumber, azureFeature, settings));
                    taskOrderNumber++;
                }
            }

            if (blankFeature.ZeroStory != null)
            {
                tasks.Add(CreateStoryAsync(internalFeature, blankFeature.ZeroStory, featureRules.ZeroStoryRules, featureRules.ZeroTaskRules, azureFeature, settings));
            }

            if (blankFeature.Stories != null)
            {
                foreach (var blankStory in blankFeature.Stories)
                {
                    tasks.Add(CreateStoryAsync(internalFeature, blankStory, featureRules.StoryRules, featureRules.TaskRules, azureFeature, settings));
                }
            }

            await Task.WhenAll(tasks);
        }

        private async Task<AzureWorkItem> CreateFeatureTaskAsync(
            Feature feature,
            BlankTask blankTask,
            TaskRules taskRules,
            int taskOrderNumber,
            AzureWorkItem azureFeature,
            AzureSettings settings)
        {
            var composer = new TitleComposer();

            var azureTask = new AzureTask
            {
                Title = composer.ComposeTaskTitle(taskRules.Title, feature, blankTask, taskOrderNumber, null, null),

                ParentUrl = azureFeature.Url,
                Description = taskRules.Description,
                Tags = taskRules.Tags.Select(tagTemplate => composer.ComposeTag(tagTemplate, feature)).ToList(),
                OriginalEstimate = blankTask.OriginalEstimate
            };

            return await _client.CreateTaskAsync(azureTask, settings);
        }

        private async Task CreateStoryAsync(
            Feature feature,
            BlankStory blankStory,
            StoryRules storyRules,
            TaskRules taskRules,
            AzureWorkItem azureFeature,
            AzureSettings settings)
        {
            var composer = new TitleComposer();

            var azureStory = new AzureStory
            {
                Title = composer.ComposeStoryTitle(storyRules.Title, feature, blankStory),
                ParentUrl = azureFeature.Url,
                Area = azureFeature.Area,
                Iteration = azureFeature.Iteration,
                Description = storyRules.Description,
                AcceptanceCriteria = storyRules.AcceptanceCriteria,
                Tags = storyRules.Tags.Select(tagTemplate => composer.ComposeTag(tagTemplate, feature)).ToList(),
            };

            azureStory.Id = (await _client.CreateUserStoryAsync(azureStory, settings)).Id;

            var tasks = new List<Task>();

            if (blankStory.Tasks != null)
            {
                var taskOrderNumber = 1;

                foreach (var task in blankStory.Tasks)
                {
                    tasks.Add(CreateStoryTaskAsync(feature, task, blankStory, taskRules, taskOrderNumber, azureStory, settings));
                    taskOrderNumber++;
                }
            }

            await Task.WhenAll(tasks);
        }

        private async Task<AzureWorkItem> CreateStoryTaskAsync(
            Feature feature,
            BlankTask blankTask,
            BlankStory blankStory,
            TaskRules taskRules,
            int taskOrderNumber,
            AzureStory azureStory,
            AzureSettings settings)
        {
            var composer = new TitleComposer();

            var azureTask = new AzureTask
            {
                Title = composer.ComposeTaskTitle(taskRules.Title, feature, blankTask, taskOrderNumber, blankStory, azureStory),
                ParentUrl = azureStory.Url,
                Area = azureStory.Area,
                Iteration = azureStory.Iteration,
                Description = taskRules.Description,
                Tags = taskRules.Tags.Select(tagTemplate => composer.ComposeTag(tagTemplate, feature)).ToList(),
                OriginalEstimate = blankTask.OriginalEstimate
            };

            return await _client.CreateTaskAsync(azureTask, settings);
        }
    }
}
