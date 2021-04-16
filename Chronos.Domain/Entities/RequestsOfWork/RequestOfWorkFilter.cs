using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.RequestsOfWork
{
    public class RequestOfWorkFilter
    {
        public int[] Ids { get; set; }
        public RequestOfWorkStatus[] Statuses { get; set; }
        public RequestOfWorkType[] RequestOfWorkTypes { get; set; }
        public string[] Products { get; set; }
    }
}
