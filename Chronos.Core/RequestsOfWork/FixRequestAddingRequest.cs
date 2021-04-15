using MediatR;

namespace Chronos.Core.RequestsOfWork
{
    public class FixRequestAddingRequest : IRequest<int>
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public bool IsPartner { get; set; }
    }
}
