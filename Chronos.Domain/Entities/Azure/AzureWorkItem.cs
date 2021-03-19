using System.Collections.Generic;
using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.Azure
{
    public class AzureWorkItem
    {
        public int Id { get; set; }

        public AzureWorkItemType Type { get; set; }

        public string Title { get; set; }

        public string Area { get; set; }

        public string Iteration { get; set; }

        public List<string> Tags { get; set; }

        public string Url { get; set; }

        public string ParentUrl { get; set; }

        public string Description { get; set; }
    }
}
