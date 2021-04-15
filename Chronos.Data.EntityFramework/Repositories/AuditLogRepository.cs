using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities;

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

        public async Task AddLog(AuditLog auditLog)
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
    }
}
