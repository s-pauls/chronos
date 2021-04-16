using System.Collections.Generic;
using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.Estimate
{
    public class EstimateItem
    {
        public Discipline Discipline{ get; set; }
        public string Name { get; set; }
        public string Assumptions { get; set; }
        public int Number { get; set; }
        public List<EstimateTask> EstimateTasks { get; set; }
    }
}
