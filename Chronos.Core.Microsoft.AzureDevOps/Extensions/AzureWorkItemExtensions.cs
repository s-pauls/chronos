using System.Collections.Generic;
using System.Linq;
using Chronos.Core.Microsoft.AzureDevOps.Constants;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Enums;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

namespace Chronos.Core.Microsoft.AzureDevOps.Extensions
{
    internal static class AzureWorkItemExtensions
    {
        public static AzureWorkItem ToAzureWorkItem(this WorkItem workItem)
        {
            var azureWorkItem = new AzureWorkItem
            {
                Id = workItem.Id.GetValueOrDefault(),
                Title = GetStringField(AzureWorkItemFieldsConstants.Title, workItem.Fields),
                Area = GetStringField(AzureWorkItemFieldsConstants.AreaPath, workItem.Fields),
                Iteration = GetStringField(AzureWorkItemFieldsConstants.IterationPath, workItem.Fields),
                Url = workItem.Url,
                ParentUrl = workItem.Relations
                    .FirstOrDefault(x => GetStringField(AzureWorkItemRelationsConstants.Name, x.Attributes) == AzureWorkItemRelationsConstants.Parent)?
                    .Url,
                Tags = GetStringField(AzureWorkItemFieldsConstants.Tags, workItem.Fields)?
                           .Split(';')
                           .Select(x => x.Trim())
                           .ToList()
                       ?? new List<string>()
            };

            var workItemType = workItem.Fields[AzureWorkItemFieldsConstants.WorkItemType] as string;

            if (workItemType == AzureWorkItemTypesConstants.Feature)
            {
                azureWorkItem.Type = AzureWorkItemType.Feature;
            }
            else if (workItemType == AzureWorkItemTypesConstants.UserStory)
            {
                azureWorkItem.Type = AzureWorkItemType.UserStory;
            }
            else if (workItemType == AzureWorkItemTypesConstants.Task)
            {
                azureWorkItem.Type = AzureWorkItemType.Task;
            }

            return azureWorkItem;
        }
        
        public static AzureStory ToAzureStory(this WorkItem workItem)
        {
            var azureWorkItem = workItem.ToAzureWorkItem();

            if (azureWorkItem.Type == AzureWorkItemType.UserStory)
            {
                return new AzureStory
                {
                    Id = azureWorkItem.Id,
                    Type = azureWorkItem.Type,
                    Title = azureWorkItem.Title,
                    Area = azureWorkItem.Area,
                    Iteration = azureWorkItem.Iteration,
                    Url = azureWorkItem.Url,
                    ParentUrl = azureWorkItem.ParentUrl,
                    Tags = azureWorkItem.Tags
                };
            }

            return null;
        }

        public static AzureTask ToAzureTask(this WorkItem workItem)
        {
            var azureWorkItem = workItem.ToAzureWorkItem();

            if (azureWorkItem.Type == AzureWorkItemType.Task)
            {
                return new AzureTask
                {
                    Id = azureWorkItem.Id,
                    Type = azureWorkItem.Type,
                    Title = azureWorkItem.Title,
                    Area = azureWorkItem.Area,
                    Iteration = azureWorkItem.Iteration,
                    Url = azureWorkItem.Url,
                    ParentUrl = azureWorkItem.ParentUrl,
                    Tags = azureWorkItem.Tags
                };
            }

            return null;
        }

        private static string GetStringField(string name, IDictionary<string, object> dictionary)
        {
            if (dictionary.ContainsKey(name))
            {
                return dictionary[name] as string;
            }
            
            return null;
        }
    }
}
