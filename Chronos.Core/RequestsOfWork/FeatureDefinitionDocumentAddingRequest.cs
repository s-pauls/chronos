using MediatR;

namespace Chronos.Core.RequestsOfWork
{
    public class FeatureDefinitionDocumentAddingRequest : IRequest<int>
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string NumberSuffix { get; set; }
    }
}
