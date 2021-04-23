using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;

namespace Chronos.Data
{
    public interface IEstimateTemplateRepository
    {
        Task<List<EstimateTemplate>> GetListAsync();
    }
}
