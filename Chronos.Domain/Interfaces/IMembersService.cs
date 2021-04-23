using System.Threading.Tasks;
using Chronos.Domain.Entities.Members;

namespace Chronos.Domain.Interfaces
{
    public interface IMembersService
    {
        Task<Member[]> GetMembers(MemberFilter query);
    }
}
