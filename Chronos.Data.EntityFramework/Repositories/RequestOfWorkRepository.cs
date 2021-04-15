using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.RequestsOfWork;
using Chronos.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class RequestOfWorkRepository : IRequestOfWorkRepository
    {
        private readonly ChronosDbContext _dbContext;

        public RequestOfWorkRepository(
            ChronosDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<List<RequestOfWork>> GetListAsync(RequestOfWorkFilter filter)
        {
            var query = _dbContext.RequestsOfWork.AsQueryable();

            if (filter != null)
            {
                if (filter.Ids.NotNullAndAny())
                {
                    query = query.Where(x => filter.Ids.Contains(x.Id));
                }

                if (filter.Statuses.NotNullAndAny())
                {
                    query = query.Where(x => filter.Statuses.Contains(x.Status));
                }
            }

            return await query.Select(x => new RequestOfWork
            {
                Id = x.Id,
                Name = x.Name,
                AdoId = x.AdoId,
                Priority = x.Priority,
                ProductId = x.ProductId,
                Status = x.Status,
                Number = x.Number,
                NumberSuffix = x.NumberSuffix,
                NumberPrefix = x.NumberPrefix,
                CSIEstimateETA = x.CSIEstimateETA,
                WEXEstimateETA = x.WEXEstimateETA,
                DesiredReleaseId = x.DesiredReleaseId,
                DocumentUrl = x.DocumentUrl,
                SkypeGroupUrl = x.SkypeGroupUrl,
            }).ToListAsync();
        }

        public async Task<RequestOfWork> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(FeatureDefinitionDocument requestOfWork)
        {
            var entity = new FeatureDefinitionDocumentEntity();
            FillRequestOfWorkEntity(entity, requestOfWork);
            await _dbContext.RequestsOfWork.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            requestOfWork.Id = entity.Id;
            return entity.Id;
        }

        public async Task<int> AddAsync(StatementOfWork requestOfWork)
        {
            var entity = new StatementOfWorkEntity
            {
                PartnerNumber = requestOfWork.PartnerNumber
            };
            FillRequestOfWorkEntity(entity, requestOfWork);
            await _dbContext.RequestsOfWork.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            requestOfWork.Id = entity.Id;
            return entity.Id;
        }

        public async Task<int> AddAsync(FixRequest requestOfWork)
        {
            var entity = new FixRequestEntity
            {
                IsPartner = requestOfWork.IsPartner,
                WexTeam = requestOfWork.WexTeam
            };
            FillRequestOfWorkEntity(entity, requestOfWork);
            await _dbContext.RequestsOfWork.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            requestOfWork.Id = entity.Id;
            return entity.Id;
        }

        public async Task ModifyAsync(RequestOfWork requestOfWork)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetMaxNumber()
        {
            return await _dbContext.RequestsOfWork.MaxAsync(x => (int?)x.Number) ?? 0;
        }

        private static void FillRequestOfWorkEntity(RequestOfWorkEntity entity, RequestOfWork requestOfWork)
        {
            entity.Id = requestOfWork.Id;
            entity.ProductId = requestOfWork.ProductId;
            entity.Status = requestOfWork.Status;
            entity.Priority = requestOfWork.Priority;
            entity.Name = requestOfWork.Name;
            entity.NumberPrefix = requestOfWork.NumberPrefix;
            entity.Number = requestOfWork.Number;
            entity.NumberSuffix = requestOfWork.NumberSuffix;
            entity.CSIEstimateETA = requestOfWork.CSIEstimateETA;
            entity.WEXEstimateETA = requestOfWork.WEXEstimateETA;
            entity.AdoId = requestOfWork.AdoId;
            entity.DesiredReleaseId = requestOfWork.DesiredReleaseId;
            entity.DocumentUrl = requestOfWork.DocumentUrl;
            entity.SkypeGroupUrl = requestOfWork.SkypeGroupUrl;
        }
    }
}
