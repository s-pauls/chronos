using MediatR;

namespace Chronos.Core.RequestsOfWork
{
    public class StatementOfWorkAddingRequest : IRequest<int>
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
    }
}
