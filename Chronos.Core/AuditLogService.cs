using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.AuditLogs;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(
            IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLog>> GetListAsync(AuditLogFilter filter)
        {
            var list = await _auditLogRepository.GetListAsync(filter);
            return list.OrderByDescending(x => x.Date).ToList();
        }

        public async Task AddAsync(string message, int objectId, ChronosObject chronosObject)
        {
            await AddAsync(message, objectId, chronosObject, false);
        }

        public async Task AddCustomAsync(string message, int objectId, ChronosObject chronosObject)
        {
            await AddAsync(message, objectId, chronosObject, true);
        }

        public async Task ModifyCustomMessageAsync(int id, string message)
        {
            var log = await _auditLogRepository.GetByIdAsync(id);

            if (log.IsCustom)
            {
                await _auditLogRepository.ModifyMessageAsync(id, message);
            }
        }

        public async Task RemoveCustomAsync(int id)
        {
            var log = await _auditLogRepository.GetByIdAsync(id);

            if (log.IsCustom)
            {
                await _auditLogRepository.RemoveAsync(id);
            }
        }

        private async Task AddAsync(string message, int objectId, ChronosObject chronosObject, bool isCustom)
        {
            await _auditLogRepository.AddAsync(new AuditLog
            {
                Message = message,
                Date = DateTime.UtcNow,
                ChronosObjectId = objectId,
                ChronosObject = chronosObject,
                IsCustom = isCustom,
                // UserId = todo
            });
        }
    }
}
