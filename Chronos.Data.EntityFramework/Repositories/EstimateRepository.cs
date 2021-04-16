using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.Estimate;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class EstimateRepository : IEstimateRepository
    {
        private readonly ChronosDbContext _dbContext;

        public EstimateRepository(
            ChronosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Estimate>> GetListAsync(EstimateFilter filter)
        {
            var query = _dbContext.Estimates
                .Include(x => x.EstimateItems)
                .ThenInclude(x => x.EstimateTasks)
               .AsQueryable();

            if (filter != null)
            {
                if (filter.Id.HasValue)
                {
                    query = query.Where(x => x.Id == filter.Id.Value);
                }

                if (filter.RequestOfWorkId.HasValue)
                {
                    query = query.Where(x => x.RequestOfWorkId == filter.RequestOfWorkId.Value);
                }
            }

            var estimates = await query.ToListAsync();

            return estimates.Select(e => new Estimate
            {
                Id = e.Id,
                EstimateTemplateId = e.EstimateTemplateId,
                Version = new Version(e.Version),
                GrandTotal = e.GrandTotal,
                EstimateItems = e.EstimateItems
                    .Select(i => new EstimateItem
                    {
                        Number = i.Number,
                        Name = i.Name,
                        Discipline = i.Discipline,
                        Assumptions = i.Assumptions,
                        EstimateTasks = i.EstimateTasks.Select(t => new EstimateTask
                        {
                            Name = t.Name,
                            Hours = t.Hours,
                        }).ToList()
                    }).ToList()
            }).ToList();
        }

        public async Task<int> AddAsync(Estimate estimate)
        {
            var estimateEntity = new EstimateEntity();
            FillEstimateEntity(estimateEntity, estimate);
            await _dbContext.Estimates.AddAsync(estimateEntity);
            await _dbContext.SaveChangesAsync();
            return estimateEntity.Id;
        }

        public async Task ModifyAsync(Estimate estimate)
        {
            var estimateEntity = await _dbContext.Estimates.FindAsync(estimate.Id);
            FillEstimateEntity(estimateEntity, estimate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbContext.Estimates.FindAsync(id);
            _dbContext.Estimates.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        private static void FillEstimateEntity(EstimateEntity entity, Estimate estimate)
        {
            entity.Version = estimate.Version?.ToString();
            entity.GrandTotal = estimate.GrandTotal;
            entity.EstimateTemplateId = estimate.EstimateTemplateId;
            entity.RequestOfWorkId = estimate.RequestOfWorkId;
            entity.EstimateItems = estimate.EstimateItems.Select(e => new EstimateItemEntity
            {
                Name = e.Name,
                Assumptions = e.Assumptions,
                Number = e.Number,
                Discipline = e.Discipline,
                EstimateTasks = e.EstimateTasks.Select(t => new EstimateItemTaskEntity
                {
                    Name = t.Name,
                    Hours = t.Hours,
                }).ToList()
            }).ToList();
        }
    }
}
