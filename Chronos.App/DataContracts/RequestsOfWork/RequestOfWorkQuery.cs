namespace Chronos.App.DataContracts.RequestsOfWork
{
    public class RequestOfWorkQuery
    {
        public int[] RequestOfWorkId { get; set; }
        public RequestOfWorkStatus[] StatusId { get; set; }
        public RequestOfWorkType[] TypeId { get; set; }
        public string[] ProductId { get; set; }
    }
}
