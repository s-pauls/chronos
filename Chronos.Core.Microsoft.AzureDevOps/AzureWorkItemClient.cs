using System;
using System.Threading.Tasks;
using Chronos.Core.Microsoft.AzureDevOps.Constants;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Enums;
using Chronos.Domain.Interfaces;
using Chronos.Core.Microsoft.AzureDevOps.Extensions;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace Chronos.Core.Microsoft.AzureDevOps
{
    public class AzureWorkItemClient : IAzureWorkItemClient
    {
        public async Task<AzureWorkItem> GetAzureWorkItemAsync(int id, AzureSettings settings)
        {
            using var client = CreateClient(settings);

            var workItem = await client.GetWorkItemAsync(settings.ProjectName, id, expand: WorkItemExpand.Relations);

            return workItem.ToAzureWorkItem();
        }

        public async Task<AzureWorkItem> CreateUserStoryAsync(AzureStory story, AzureSettings settings)
        {
            var document = new JsonPatchDocumentBuilder()
                .AddTitle(story.Title)
                .AddAreaPath(story.Area)
                .AddIterationPath(story.Iteration)
                .AddTags(story.Tags)
                .AddParent(story.ParentUrl)
                .AddDescription(story.Description)
                .AddAcceptanceCriteria(story.AcceptanceCriteria)
                .Build();
            
            using var client = CreateClient(settings);

            var workItem = await client.CreateWorkItemAsync(document, settings.ProjectName, AzureWorkItemTypesConstants.UserStory);

            return workItem.ToAzureWorkItem();
        }

        public async Task<AzureWorkItem> CreateTaskAsync(AzureTask task, AzureSettings settings)
        {
            var document = new JsonPatchDocumentBuilder()
                .AddTitle(task.Title)
                .AddAreaPath(task.Area)
                .AddIterationPath(task.Iteration)
                .AddTags(task.Tags)
                .AddParent(task.ParentUrl)
                .AddDescription(task.Description)
                .AddActivity(GetActivity(task.Activity))
                .AddOriginalEstimate(task.OriginalEstimate)
                .AddRemainingWork(task.Remaining)
                .Build();

            using var client = CreateClient(settings);

            var workItem = await client.CreateWorkItemAsync(document, settings.ProjectName, AzureWorkItemTypesConstants.Task);

            return workItem.ToAzureWorkItem();
        }

        private WorkItemTrackingHttpClient CreateClient(AzureSettings settings)
        {
            var path = $"{settings.ApiUrl}/{settings.Organization}";
            
            var credential = new VssBasicCredential("", settings.Token);

            var connection = new VssConnection(new Uri(path), credential);

            return connection.GetClient<WorkItemTrackingHttpClient>();
        }

        private string GetActivity(AzureActivityType activityType)
        {
            switch (activityType)
            {
                case AzureActivityType.DEV:
                    return AzureWorkItemActivitiesConstants.Development;

                case AzureActivityType.BA:
                    return AzureWorkItemActivitiesConstants.Requirements;

                case AzureActivityType.QA:
                    return AzureWorkItemActivitiesConstants.Testing;
                
                default:
                    return null;
            }
        }
    }
}
