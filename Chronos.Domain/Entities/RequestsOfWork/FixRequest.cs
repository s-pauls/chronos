namespace Chronos.Domain.Entities.RequestsOfWork
{
    public class FixRequest : RequestOfWork
    {
        public bool IsPartner { get; set; }
        public string WexTeam{ get; set; }
    }
}
