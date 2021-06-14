using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.EstimateTemplates;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class EstimateTemplateRepository : IEstimateTemplateRepository
    {
        private readonly ChronosDbContext _dbContext;

        public EstimateTemplateRepository(
            ChronosDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<List<EstimateTemplate>> GetListAsync()
        {
            var entities = await _dbContext.EstimateTemplates.ToListAsync();
            return entities.Select(TurnToModel).ToList();
        }

        public async Task<EstimateTemplate> GetByIdAsync(int id)
        {
            var entity = await _dbContext.EstimateTemplates.FindAsync(id);
            return TurnToModel(entity);
        }

        public async Task<int> AddAsync(EstimateTemplate estimateTemplate)
        {
            var entity = new EstimateTemplateEntity();
            FillEntity(entity, estimateTemplate);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task ModifyAsync(EstimateTemplate estimateTemplate)
        {
            var entity = await _dbContext.EstimateTemplates.FindAsync(estimateTemplate.Id);
            FillEntity(entity, estimateTemplate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbContext.EstimateTemplates.FindAsync(id);
            _dbContext.EstimateTemplates.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private void FillEntity(EstimateTemplateEntity entity, EstimateTemplate estimateTemplate)
        {
            entity.Value = JsonConvert.SerializeObject(estimateTemplate);
        }

        private EstimateTemplate TurnToModel(EstimateTemplateEntity entity)
        {
            var estimateTemplate = JsonConvert.DeserializeObject<EstimateTemplate>(entity.Value);
            estimateTemplate.Id = entity.Id;
            return estimateTemplate;
        }
    }
}
