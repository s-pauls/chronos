using System.Collections.Generic;
using Chronos.Domain.Enums;

namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateItemEntity
    {
        public int Id { get; set; }
        public int EstimateId { get; set; }
        public EstimateEntity Estimate { get; set; }
        public string Name { get; set; }
        public string Assumptions { get; set; }
        public int Number { get; set; }
        public Discipline Discipline { get; set; }
        public List<EstimateItemTaskEntity> EstimateTasks { get; set; }
    }
}
