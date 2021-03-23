using System.Threading.Tasks;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.User;

namespace Chronos.Data
{
    public interface IAuditLogRepository
    {
        Task AddLog(UserContext context, AuditLog auditLog);
    }
}
