using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.FeatureRules;

namespace Chronos.Data
{
    public interface IFeatureRulesRepository
    {
        public Task<List<FeatureRules>> GetListAsync();
        public Task<FeatureRules> GetByIdAsync(int id);
        public Task<int> AddAsync(FeatureRules featureRules);
        public Task ModifyAsync(FeatureRules featureRules);
        public Task RemoveAsync(int id);
    }
}
