using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;
using Microsoft.EntityFrameworkCore;

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
            return await _dbContext.EstimateTemplates.Select(x => new EstimateTemplate
            {
                Id = x.Id,
                Name = x.Value,
                Version = x.Version
            }).ToListAsync();
        }
    }
}
