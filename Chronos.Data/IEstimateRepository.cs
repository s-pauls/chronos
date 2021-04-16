using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;

namespace Chronos.Data
{
    public interface IEstimateRepository
    {
        Task<List<Estimate>> GetListAsync(EstimateFilter filter);
        Task<int> AddAsync(Estimate estimate);
        Task ModifyAsync(Estimate estimate);
        Task RemoveAsync(int id);
    }
}
