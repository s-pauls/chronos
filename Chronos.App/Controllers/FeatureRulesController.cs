using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainModels = Chronos.Domain.Entities.FeatureRules;
using ApiContract = Chronos.App.DataContracts.FeatureRules;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/feature-rules")]
    [ApiController]
    public class FeatureRulesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFeatureRulesService _featureRulesService;

        public FeatureRulesController(
            IMapper mapper,
            IFeatureRulesService featureRulesService)
        {
            _mapper = mapper;
            _featureRulesService = featureRulesService;
        }

        // GET: api/<FeatureRulesController>
        [HttpGet]
        public async Task<ApiListResponse<ApiContract.FeatureRulesWithId>> GetListAsync()
        {
            var list = await _featureRulesService.GetListAsync();
            var apiData = _mapper.Map<ApiContract.FeatureRulesWithId[]>(list);
            return new ApiListResponse<ApiContract.FeatureRulesWithId>(apiData);
        }

        // GET api/<FeatureRulesController>/5
        [HttpGet("{id}")]
        public async Task<ApiResponse<ApiContract.FeatureRulesWithId>> GetItemByIdAsync(int id)
        {
            var item = await _featureRulesService.GetByIdAsync(id);
            var apiData = _mapper.Map<ApiContract.FeatureRulesWithId>(item);
            return new ApiResponse<ApiContract.FeatureRulesWithId>(apiData);
        }

        [HttpGet("default")]
        public ApiResponse<ApiContract.FeatureRules> GetDefaultItem()
        {
            var item = _featureRulesService.GetDefaultItem();
            var apiData = _mapper.Map<ApiContract.FeatureRules>(item);
            return new ApiResponse<ApiContract.FeatureRules>(apiData);
        }

        // POST api/<FeatureRulesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ApiContract.FeatureRules featureRules)
        {
            var model = _mapper.Map<DomainModels.FeatureRules>(featureRules);
            await _featureRulesService.AddAsync(model);
            return NoContent();
        }

        // PUT api/<FeatureRulesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ApiContract.FeatureRules featureRules)
        {
            var model = _mapper.Map<DomainModels.FeatureRules>(featureRules);
            model.Id = id;
            await _featureRulesService.ModifyAsync(model);
            return NoContent();
        }

        // DELETE api/<FeatureRulesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _featureRulesService.RemoveAsync(id);
            return NoContent();
        }
    }
}
