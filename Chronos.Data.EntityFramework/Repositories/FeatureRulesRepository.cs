using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.FeatureRules;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class FeatureRulesRepository : IFeatureRulesRepository
    {
        private readonly ChronosDbContext _dbContext;

        public FeatureRulesRepository(
            ChronosDbContext dbContext
             )
        {
            _dbContext = dbContext;
        }

        public async Task<List<FeatureRules>> GetListAsync()
        {
            var entities = await _dbContext.FeatureRules.ToListAsync();
            return entities.Select(TurnToModel).ToList();
        }

        public async Task<FeatureRules> GetByIdAsync(int id)
        {
            var entity = await _dbContext.FeatureRules.FindAsync(id);
            return TurnToModel(entity);
        }

        public async Task<int> AddAsync(FeatureRules featureRules)
        {
            var entity = new FeatureRulesEntity();
            FillEntity(entity, featureRules);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task ModifyAsync(FeatureRules featureRules)
        {
            var entity = await _dbContext.FeatureRules.FindAsync(featureRules.Id);
            FillEntity(entity, featureRules);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbContext.FeatureRules.FindAsync(id);
            _dbContext.FeatureRules.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private void FillEntity(FeatureRulesEntity entity, FeatureRules featureRules)
        {
            entity.Name = featureRules.Name;
            entity.Rules = JsonConvert.SerializeObject(featureRules);
        }

        private FeatureRules TurnToModel(FeatureRulesEntity entity)
        {
            var featureRules = JsonConvert.DeserializeObject<FeatureRules>(entity.Rules);
            featureRules.Id = entity.Id;
            return featureRules;
        }
    }
}
