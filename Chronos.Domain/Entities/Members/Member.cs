using System;

namespace Chronos.Domain.Entities.Members
{
    public class Member
    {
        public Guid MemberUid { get; set; }
        public MemberStatus MemberStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CoherentEmail { get; set; }
        public string SkypeId { get; set; }
        public bool IsCSI { get; set; }
        public string WexEmail { get; set; }
        public string WexAccountName { get; set; }
        public string WexAccountImageUrl { get; set; }
        public Guid? TeamUid { get; set; }
        public string TeamName { get; set; }
    }
}
