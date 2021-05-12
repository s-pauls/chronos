using System.Collections.Generic;

namespace Chronos.App.DataContracts.Blank
{
    public class BlankStory
    {
        public int StoryId { get; set; }
        
        public string Name { get; set; }

        public List<BlankTask> Tasks { get; set; }
        
        public int OrderNumber { get; set; }
        
        public List<string> Tags { get; set; }
        
        public List<string> SuggestedTags { get; set; }
    }
}
