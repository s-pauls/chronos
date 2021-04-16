using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Interfaces;
using MediatR;

namespace Chronos.Core.Estimates
{
    public class EstimateFromExcelAddingRequestHandler : INotificationHandler<EstimateFromExcelAddingRequest>
    {
        private readonly IEstimateService _estimateService;
        private readonly IEstimateParser _estimateParser;


        public EstimateFromExcelAddingRequestHandler(
            IEstimateService estimateService,
            IEstimateParser estimateParser)
        {
            _estimateService = estimateService;
            _estimateParser = estimateParser;
        }

        public async Task Handle(EstimateFromExcelAddingRequest request, CancellationToken cancellationToken)
        {
            Estimate estimate = new Estimate
            {
                RequestOfWorkId = request.RequestOfWorkId,
                EstimateTemplateId = request.EstimateTemplateId,
                Version = new Version("1.0"),
            };

            var data = _estimateParser.Parse(request.FilePath);

            if (data.Any())
            {
                estimate.EstimateItems = data;
                await _estimateService.AddAsync(estimate);
            }
        }


    }

}
