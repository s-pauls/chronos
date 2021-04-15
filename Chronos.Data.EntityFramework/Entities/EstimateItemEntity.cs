namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateItemEntity
    {
        public int Id { get; set; }
        public int EstimateId { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public EstimateEntity Estimate { get; set; }
    }
}
