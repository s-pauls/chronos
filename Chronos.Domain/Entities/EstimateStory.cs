using System.Collections.Generic;

namespace Chronos.Domain.Entities
{
    public class EstimateStory
    {
        public string Title { get; set; }
        public int Number { get; set; }
        IEnumerable<EstimateTask> Tasks { get; set; }
    }
}
