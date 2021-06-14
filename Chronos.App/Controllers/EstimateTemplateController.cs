using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainModels = Chronos.Domain.Entities.EstimateTemplates;
using ApiContract = Chronos.App.DataContracts.EstimateTemplates;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/estimate-templates")]
    [ApiController]
    public class EstimateTemplateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstimateTemplateService _estimateTemplateService;

        public EstimateTemplateController(
            IMapper mapper,
            IEstimateTemplateService estimateTemplateService)
        {
            _mapper = mapper;
            _estimateTemplateService = estimateTemplateService;
        }

        [HttpGet]
        public async Task<ApiListResponse<ApiContract.EstimateTemplateWithId>> GetListAsync()
        {
            var list = await _estimateTemplateService.GetListAsync();
            var apiData = _mapper.Map<ApiContract.EstimateTemplateWithId[]>(list);
            return new ApiListResponse<ApiContract.EstimateTemplateWithId>(apiData);
        }

        [HttpGet("{id}")]
        public async Task<ApiResponse<ApiContract.EstimateTemplateWithId>> GetItemByIdAsync(int id)
        {
            var item = await _estimateTemplateService.GetByIdAsync(id);
            var apiData = _mapper.Map<ApiContract.EstimateTemplateWithId>(item);
            return new ApiResponse<ApiContract.EstimateTemplateWithId>(apiData);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ApiContract.EstimateTemplate featureRules)
        {
            var model = _mapper.Map<DomainModels.EstimateTemplate>(featureRules);
            await _estimateTemplateService.AddAsync(model);
            return NoContent();
        }
    }
}
