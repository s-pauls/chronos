using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities.EstimateTemplates;
using Chronos.Domain.Exceptions;
using Chronos.Domain.Interfaces;
using Chronos.Utilities.Comparers;

namespace Chronos.Core.EstimateTemplates
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

        public async Task<EstimateTemplate> GetByIdAsync(int id)
        {
            return await _estimateTemplateRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(EstimateTemplate estimateTemplate)
        {
            CheckEstimateTemplate(estimateTemplate);
            return await _estimateTemplateRepository.AddAsync(estimateTemplate);
        }

        public async Task ModifyAsync(EstimateTemplate estimateTemplate)
        {
            CheckEstimateTemplate(estimateTemplate);
            await _estimateTemplateRepository.ModifyAsync(estimateTemplate);
        }

        public async Task RemoveAsync(int id)
        {
            await _estimateTemplateRepository.RemoveAsync(id);
        }

        private void CheckEstimateTemplate(EstimateTemplate estimateTemplate)
        {
            var generalValuesNames = estimateTemplate.GeneralValues.Select(x => x.Name).ToList();
            foreach (var item in estimateTemplate.Items)
            {
                if (generalValuesNames.Contains(item.Name, new StringOrdinalIgnoreCaseComparer()))
                {
                    throw new CustomException($"{item.Name} value is used in General values");
                }
            }

            var availableTaskNames = estimateTemplate.Tasks.Select(x => x.TaskName).ToList();
            foreach (var item in estimateTemplate.Items)
            {
                if (!availableTaskNames.Contains(item.TaskName, new StringOrdinalIgnoreCaseComparer()))
                {
                    throw new CustomException($"Item {item.Name} refers to a non-existent task {item.TaskName}");
                }
            }
        }
    }
}
