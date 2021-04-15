namespace Chronos.App.DataContracts.RequestsOfWork
{
    public class RequestOfWork
    {
        public int RequestOfWorkId { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public string FullNumber { get; set; }
        public int? Priority { get; set; }
        public RequestOfWorkStatus StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
