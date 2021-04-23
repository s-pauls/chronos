using System.Linq;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Members;
using Chronos.Domain.Interfaces;
using Organization.WebApi.Client.Members;
using Organization.WebApi.PublicDataContract.Members;
using DomainModels = Chronos.Domain.Entities.Members;
using OrganizationMemberContract = Organization.WebApi.PublicDataContract.Members;

namespace Chronos.Core
{
    public class MembersService : IMembersService
    {
        private readonly IMembersClient _membersClient;

        public MembersService(
            IMembersClient membersClient)
        {
            _membersClient = membersClient;
        }

        public async Task<DomainModels.Member[]> GetMembers(MemberFilter filter)
        {
            var query = new MemberQuery
            {
                SearchText = filter.SearchText,
                MemberRoleId = filter.MemberRoleId.Select(x => (OrganizationMemberContract.MemberRole)x).ToArray(),
                MemberStatusId = filter.MemberStatusId.Select(x => (OrganizationMemberContract.MemberStatus)x).ToArray(),
                ProjectUid = filter.ProjectUid,
                TeamUid = filter.TeamUid
            };

            var members = await _membersClient.GetMembersAsync(query);

            return members.Select(x => new DomainModels.Member
            {
                TeamName = x.TeamName,
                TeamUid = x.TeamUid,
                CoherentEmail = x.CoherentEmail,
                FirstName = x.FirstName,
                IsCSI = x.IsCSI,
                LastName = x.LastName,
                SkypeId = x.SkypeId,
                MemberStatus = (DomainModels.MemberStatus)x.MemberStatus,
                MemberUid = x.MemberUid,
                WexEmail = x.WexEmail,
                WexAccountImageUrl = x.WexAccountImageUrl,
                WexAccountName = x.WexAccountName
            }).ToArray();
        }

    }
}
