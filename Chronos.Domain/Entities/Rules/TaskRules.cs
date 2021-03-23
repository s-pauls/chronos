using System.Collections.Generic;

namespace Chronos.Domain.Entities.Rules
{
    public class TaskRules
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }
    }
}
