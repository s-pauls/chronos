using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.AuditLogs;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Interfaces;

namespace Chronos.Core.Estimates
{
    public class EstimateService : IEstimateService
    {
        private readonly IEstimateRepository _estimateRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public EstimateService(
            IEstimateRepository estimateRepository,
            IAuditLogRepository auditLogRepository)
        {
            _estimateRepository = estimateRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<Estimate>> GetListAsync(int requestOfWorkId)
        {
            return await _estimateRepository.GetListAsync(new EstimateFilter { RequestOfWorkId = requestOfWorkId });
        }

        public async Task<Estimate> GetByIdAsync(int id)
        {
            var estimates = await _estimateRepository.GetListAsync(new EstimateFilter { Id = id });
            return estimates.SingleOrDefault();
        }

        public async Task AddAsync(Estimate estimate)
        {
            var estimateId = await _estimateRepository.AddAsync(estimate);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ChronosObject = ChronosObject.RequestOfWork,
                ChronosObjectId = estimate.RequestOfWorkId,
                Date = DateTime.UtcNow,
                Message = $"The Estimate v:{estimate.Version} added",
                UserId = 1 // todo
            });
        }

        public async Task ModifyAsync(Estimate estimate)
        {
            await _estimateRepository.ModifyAsync(estimate);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ChronosObject = ChronosObject.RequestOfWork,
                ChronosObjectId = estimate.RequestOfWorkId,
                Date = DateTime.UtcNow,
                Message = $"The Estimate v:{estimate.Version} updated",
                UserId = 1 // todo
            });
        }

        public async Task RemoveAsync(int id)
        {
            var estimate = await GetByIdAsync(id);
            if (estimate != null)
            {
                await _estimateRepository.RemoveAsync(id);
                await _auditLogRepository.AddAsync(new AuditLog
                {
                    ChronosObject = ChronosObject.RequestOfWork,
                    ChronosObjectId = estimate.RequestOfWorkId,
                    Date = DateTime.UtcNow,
                    Message = $"The Estimate v:{estimate.Version} removed",
                    UserId = 1 // todo
                });
            }
        }
    }
}
