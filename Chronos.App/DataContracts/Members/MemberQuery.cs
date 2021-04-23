using System;

namespace Chronos.App.DataContracts.Members
{
    public class MemberQuery
    {
        public string SearchText { get; set; }
        public MemberStatus[] MemberStatusId { get; set; }
        public MemberRole[] MemberRoleId { get; set; }
        public Guid[] TeamUid { get; set; }
        public Guid[] ProjectUid { get; set; }
    }
}
