using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.AuditLogs;

namespace Chronos.Data
{
    public interface IAuditLogRepository
    {
        Task<List<AuditLog>> GetListAsync(AuditLogFilter filter);
        Task<AuditLog> GetByIdAsync(int id);
        Task AddAsync(AuditLog auditLog);
        Task ModifyMessageAsync(int id, string message);
        Task RemoveAsync(int id);
    }
}
