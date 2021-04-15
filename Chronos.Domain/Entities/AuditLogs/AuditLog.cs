using System;

namespace Chronos.Domain.Entities.AuditLogs
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int ChronosObjectId { get; set; }
        public ChronosObject ChronosObject { get; set; }
        public string Message { get; set; }
        public bool IsCustom { get; set; }
    }
}
