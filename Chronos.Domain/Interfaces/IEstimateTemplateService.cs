using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.EstimateTemplates;

namespace Chronos.Domain.Interfaces
{
    public interface IEstimateTemplateService
    {
        Task<List<EstimateTemplate>> GetListAsync();
        Task<EstimateTemplate> GetByIdAsync(int id);
        Task<int> AddAsync(EstimateTemplate estimateTemplate);
        Task ModifyAsync(EstimateTemplate estimateTemplate);
        Task RemoveAsync(int id);
    }
}
