using Chronos.Domain.Enums;

namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateItemTaskEntity
    {
        public int Id { get; set; }
        public int EstimateItemId { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public Discipline Discipline { get; set; }
        public EstimateItemEntity EstimateItem { get; set; }
    }
}
