using Chronos.Domain.Entities;
using System.Threading.Tasks;
using Chronos.Domain.Entities.User;

namespace Chronos.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string accessToken);
    }
}
