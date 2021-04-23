using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ApiContract = Chronos.App.DataContracts.Estimates;

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
        public async Task<ApiListResponse<ApiContract.EstimateTemplate>> GetListAsync()
        {
            var list = await _estimateTemplateService.GetListAsync();
            var apiData = _mapper.Map<ApiContract.EstimateTemplate[]>(list);
            return new ApiListResponse<ApiContract.EstimateTemplate>(apiData);
        }
    }
}
