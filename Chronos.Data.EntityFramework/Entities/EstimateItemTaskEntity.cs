namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateItemTaskEntity
    {
        public int Id { get; set; }
        public int EstimateItemId { get; set; }
        public EstimateItemEntity EstimateItem { get; set; }
        public string Name { get; set; }
        public double Hours { get; set; }
    }
}
