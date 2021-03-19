using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.Azure
{
    public class AzureTask : AzureWorkItem
    {
        public AzureActivityType Activity { get; set; }

        public decimal OriginalEstimate { get; set; }

        public decimal Remaining { get; set; }

        public decimal Completed { get; set; }
    }
}
