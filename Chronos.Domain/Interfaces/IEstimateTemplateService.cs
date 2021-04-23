using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;

namespace Chronos.Domain.Interfaces
{
    public interface IEstimateTemplateService
    {
        Task<List<EstimateTemplate>> GetListAsync();
    }
}
