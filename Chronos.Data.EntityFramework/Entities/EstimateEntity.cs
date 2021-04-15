namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateEntity
    {
        public int Id { get; set; }
        public int EstimateTemplateId{ get; set; }
        public string Version { get; set; }
        public double GrandTotal { get; set; }
        public EstimateTemplateEntity EstimateTemplate { get; set; }
    }
}
