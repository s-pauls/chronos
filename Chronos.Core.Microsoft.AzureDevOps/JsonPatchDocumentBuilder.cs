using System.Collections.Generic;
using System.Linq;
using Chronos.Core.Microsoft.AzureDevOps.Constants;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace Chronos.Core.Microsoft.AzureDevOps
{
    internal class JsonPatchDocumentBuilder
    {
        private readonly JsonPatchDocument _document;

        public JsonPatchDocumentBuilder()
        {
            _document = new JsonPatchDocument();
        }

        public JsonPatchDocumentBuilder AddTitle(string title)
        {
            if (title != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.Title}", title);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddAreaPath(string areaPath)
        {
            if (areaPath != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.AreaPath}", areaPath);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddIterationPath(string iterationPath)
        {
            if (iterationPath != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.IterationPath}", iterationPath);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddTags(List<string> tags)
        {
            if (tags != null && tags.Any())
            {
                _document.Add(new JsonPatchOperation
                {
                    Operation = Operation.Add,
                    Path = $"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.Tags}",
                    Value = tags.Aggregate((x, y) => $"{x}; {y}")
                });
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddDescription(string description)
        {
            if (description != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.Description}", description);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddAcceptanceCriteria(string acceptanceCriteria)
        {
            if (acceptanceCriteria != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.AcceptanceCriteria}", acceptanceCriteria);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddActivity(string activity)
        {
            if (activity != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.Activity}", activity);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddOriginalEstimate(decimal? originalEstimate)
        {
            if (originalEstimate != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.OriginalEstimate}", originalEstimate);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddRemainingWork(decimal? remainingWork)
        {
            if (remainingWork != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.RemainingWork}", remainingWork);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddCompletedWork(decimal? completedWork)
        {
            if (completedWork != null)
            {
                AddPatch($"/{AzureWorkItemFieldsConstants.Fields}/{AzureWorkItemFieldsConstants.CompletedWork}", completedWork);
            }

            return this;
        }

        public JsonPatchDocumentBuilder AddParent(string url)
        {
            _document.Add(new JsonPatchOperation
            {
                Operation = Operation.Add,
                Path = "/relations/-",
                Value = new
                {
                    rel = "System.LinkTypes.Hierarchy-Reverse",
                    url = url
                }
            });

            return this;
        }

        public JsonPatchDocument Build()
        {
            return _document;
        }


        private void AddPatch(string path, object value)
        {
            _document.Add(new JsonPatchOperation
            {
                Operation = Operation.Add,
                Path = path,
                Value = value
            });
        }
    }
}
