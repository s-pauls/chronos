namespace Chronos.Data.EntityFramework.Entities
{
    public class FeatureBlankEntity
    {
        public int Id { get; set; }
        public int RequestOfWorkId { get; set; }
        public RequestOfWorkEntity RequestOfWork { get; set; }
        public int? EstimateId { get; set; }
        public EstimateEntity Estimate { get; set; }
        public string Value { get; set; }
    }
}
