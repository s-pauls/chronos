namespace Chronos.Domain.Entities.AuditLogs
{
    public class AuditLogFilter
    {
        public int[] Ids { get; set; }
        public int? ChronosObjectId { get; set; }
        public ChronosObject? ChronosObjects { get; set; }
        public bool? IsCustom { get; set; }
    }
}
