using System.Threading;
using System.Threading.Tasks;
using Chronos.Domain.Entities.RequestsOfWork;
using Chronos.Domain.Enums;
using Chronos.Domain.Interfaces;
using MediatR;

namespace Chronos.Core.RequestsOfWork
{
    public class RequestOfWorkRequestHandler : 
        IRequestHandler<FixRequestAddingRequest, int>,
        IRequestHandler<StatementOfWorkAddingRequest, int>,
        IRequestHandler<FeatureDefinitionDocumentAddingRequest, int>
    {
        private readonly IRequestOfWorkService _requestOfWorkService;

        public RequestOfWorkRequestHandler(
            IRequestOfWorkService requestOfWorkService)
        {
            _requestOfWorkService = requestOfWorkService;
        }

        public async Task<int> Handle(FeatureDefinitionDocumentAddingRequest request, CancellationToken cancellationToken)
        {
            int number = await _requestOfWorkService.GetNextNumber();

            var fixRequest = new FeatureDefinitionDocument
            {
                Name = request.Name,
                ProductId = request.ProductId,

                NumberPrefix = Labels.NumberPrefix_FeatureDefinitionDocument,
                Number = number,
                NumberSuffix = request.NumberSuffix,

                Status = RequestOfWorkStatus.NotStarted
            };

            return await _requestOfWorkService.AddAsync(fixRequest);
        }

        public async Task<int> Handle(StatementOfWorkAddingRequest request, CancellationToken cancellationToken)
        {
            int number = await _requestOfWorkService.GetNextNumber();

            var fixRequest = new StatementOfWork
            {
                Name = request.Name,
                ProductId = request.ProductId,

                NumberPrefix = Labels.NumberPrefix_StatementOfWork,
                Number = number,

                Status = RequestOfWorkStatus.NotStarted
            };

            return await _requestOfWorkService.AddAsync(fixRequest);
        }

        public async Task<int> Handle(FixRequestAddingRequest request, CancellationToken cancellationToken)
        {

            int number = await _requestOfWorkService.GetNextNumber();

            var fixRequest = new FixRequest
            {
                Name = request.Name,
                ProductId = request.ProductId,
                IsPartner = request.IsPartner,

                NumberPrefix = Labels.NumberPrefix_FixRequest,
                Number = number,

                Status = RequestOfWorkStatus.NotStarted
            };

            return await _requestOfWorkService.AddAsync(fixRequest);
        }
    }
}
