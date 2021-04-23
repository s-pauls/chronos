using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class EstimateTemplateService : IEstimateTemplateService
    {
        private readonly IEstimateTemplateRepository _estimateTemplateRepository;

        public EstimateTemplateService(
            IEstimateTemplateRepository estimateTemplateRepository)
        {
            _estimateTemplateRepository = estimateTemplateRepository;
        }
        
        public async Task<List<EstimateTemplate>> GetListAsync()
        {
            return await _estimateTemplateRepository.GetListAsync();
        }
    }
}
