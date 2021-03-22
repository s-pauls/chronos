using System;
using Chronos.Domain.Entities;

namespace Chronos.Data.EntityFramework.Entities
{
    public class AuditLogEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public int ObjectId { get; set; }
        public ChronosObject ObjectType { get; set; }
    }
}
