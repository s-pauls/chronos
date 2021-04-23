using MediatR;

namespace Chronos.Core.Estimates
{
    public class EstimateFromExcelAddingRequest : INotification
    {
        public int RequestOfWorkId { get; set; }
        public int EstimateTemplateId { get; set; }
        public string Version { get; set; }
        public string FilePath { get; set; }
    }
}
