﻿using System.Threading.Tasks;
using Chronos.Domain.Entities;

namespace Chronos.Data
{
    public interface IAuditLogRepository
    {
        Task AddLog(UserContext context, AuditLog auditLog);
    }
}
