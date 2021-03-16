namespace Chronos.Data
{
    public interface IAuditLogRepository
    {
        void Add(int userId, string message);
    }
}
