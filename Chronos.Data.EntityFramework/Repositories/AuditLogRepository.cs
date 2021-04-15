using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.AuditLogs;
using Chronos.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly ChronosDbContext _dbContext;

        public AuditLogRepository(
            ChronosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AuditLog>> GetListAsync(AuditLogFilter filter)
        {
            var query = _dbContext.AuditLogs.AsQueryable();

            if (filter != null)
            {
                if (filter.Ids.NotNullAndAny())
                {
                    query = query.Where(x => filter.Ids.Contains(x.Id));
                }

                if (filter.ChronosObjects.HasValue)
                {
                    query = query.Where(x => filter.ChronosObjects.Value == x.ObjectType);
                }

                if (filter.ChronosObjectId.HasValue)
                {
                    query = query.Where(x => filter.ChronosObjectId.Value == x.ObjectId);
                }

            }

            return await query.Select(x => new AuditLog
            {
                Id = x.Id,
                Date = x.Date,
                IsCustom = x.IsCustom,
                ChronosObject = x.ObjectType,
                ChronosObjectId = x.ObjectId,
                Message = x.Message,
                UserId = x.UserId
            }).ToListAsync();
        }

        public async Task<AuditLog> GetByIdAsync(int id)
        {
            var entity = await _dbContext.AuditLogs.FindAsync(id);
            return new AuditLog
            {
                Id = entity.Id,
                Date = entity.Date,
                IsCustom = entity.IsCustom,
                ChronosObject = entity.ObjectType,
                ChronosObjectId = entity.ObjectId,
                Message = entity.Message,
                UserId = entity.UserId
            };
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            var auditLogEntity = new AuditLogEntity
            {
                Message = auditLog.Message,
                ObjectId = auditLog.ChronosObjectId,
                ObjectType = auditLog.ChronosObject,
                Date = auditLog.Date,
                UserId = auditLog.UserId,
                IsCustom = auditLog.IsCustom
            };
            await _dbContext.AuditLogs.AddAsync(auditLogEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ModifyMessageAsync(int id, string message)
        {
            var entity = await _dbContext.AuditLogs.FindAsync(id);
            entity.Message = message;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbContext.AuditLogs.FindAsync(id);
            _dbContext.AuditLogs.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
