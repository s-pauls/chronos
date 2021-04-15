namespace Chronos.Data.EntityFramework.Entities
{
    public class EstimateMemberEntity
    {
        public int Id { get; set; }
        public int EstimateId { get; set; }
        public string MemberId { get; set; }
        public double SpentHours { get; set; }
    }
}
