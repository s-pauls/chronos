using System.Collections.Generic;

namespace Chronos.Domain.Entities
{
    public class StoryRules
    {
        public string Title { get; set; }

        public string Description { get; set; }
        
        public string AcceptanceCriteria { get; set; }

        public List<string> Tags { get; set; }
    }
}
