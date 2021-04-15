namespace Chronos.Domain.Enums
{
    public enum RequestOfWorkStatus
    {
        NotSentToCSI = 1,
        NotStarted = 2,
        InProgress = 3,
        Blocked = 4,
        OnHold = 5,
        SentToWEX = 6,
        Approved = 7,
        Removed = 8,
        Released = 9,
        ReleasedNotReproducible = 10,
        ReleasedReproducible = 11
    }
}
