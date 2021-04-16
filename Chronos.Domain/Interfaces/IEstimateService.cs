using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;

namespace Chronos.Domain.Interfaces
{
    public interface IEstimateService
    {
        Task<List<Estimate>> GetListAsync(int requestOfWorkId);
        Task<Estimate> GetByIdAsync(int id);
        Task AddAsync(Estimate estimate);
        Task ModifyAsync(Estimate estimate);
        Task RemoveAsync(int id);
    }
}
