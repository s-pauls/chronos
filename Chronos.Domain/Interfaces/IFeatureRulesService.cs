using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.FeatureRules;

namespace Chronos.Domain.Interfaces
{
    public interface IFeatureRulesService
    {
        Task<List<FeatureRules>> GetListAsync();
        Task<FeatureRules> GetByIdAsync(int id);
        FeatureRules GetDefaultItem();
        Task<int> AddAsync(FeatureRules featureRules);
        Task ModifyAsync(FeatureRules featureRules);
        Task RemoveAsync(int id);
    }
}
