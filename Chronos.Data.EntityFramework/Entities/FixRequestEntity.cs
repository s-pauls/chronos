namespace Chronos.Data.EntityFramework.Entities
{
    public class FixRequestEntity : RequestOfWorkEntity
    {
        public bool IsPartner { get; set; }
        public string WexTeam { get; set; }
    }
}
