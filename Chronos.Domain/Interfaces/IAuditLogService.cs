using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.AuditLogs;

namespace Chronos.Domain.Interfaces
{
    public interface IAuditLogService
    {
        Task<List<AuditLog>> GetListAsync(AuditLogFilter filter);
        Task AddAsync(string message, int objectId, ChronosObject chronosObject);
        Task AddCustomAsync(string message, int objectId, ChronosObject chronosObject);
        Task ModifyCustomMessageAsync(int id, string message);
        Task RemoveCustomAsync(int id);
    }
}
