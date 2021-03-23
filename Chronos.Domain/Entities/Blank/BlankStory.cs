using System.Collections.Generic;

namespace Chronos.Domain.Entities.Blank
{
    public class BlankStory
    {
        public string Name { get; set; }

        public List<BlankTask> Tasks { get; set; }
        
        public int OrderNumber { get; set; }
    }
}
