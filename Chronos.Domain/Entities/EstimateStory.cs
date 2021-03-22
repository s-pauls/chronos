using System.Collections.Generic;

namespace Chronos.Domain.Entities
{
    public class EstimateStory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        List<EstimateTask> Tasks { get; set; }
    }
}
