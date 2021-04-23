using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestModels = Chronos.Core.RequestsOfWork;
using DomainModels = Chronos.Domain.Entities.RequestsOfWork;
using ApiContract = Chronos.App.DataContracts.RequestsOfWork;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/requests-of-work")]
    [ApiController]
    public class RequestsOfWorkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IRequestOfWorkService _requestOfWorkService;

        public RequestsOfWorkController(
            IMapper mapper,
            IMediator mediator,
            IRequestOfWorkService requestOfWorkService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _requestOfWorkService = requestOfWorkService;
        }

        [HttpGet]
        public async Task<ApiListResponse<ApiContract.RequestOfWork>> GetListAsync([FromQuery]ApiContract.RequestOfWorkQuery query)
        {
            var filter = _mapper.Map<DomainModels.RequestOfWorkFilter>(query);
            var list = await _requestOfWorkService.GetListAsync(filter);
            var apiData = _mapper.Map<ApiContract.RequestOfWork[]>(list);
            return new ApiListResponse<ApiContract.RequestOfWork>(apiData);
        }

        //[HttpGet("{id}")]
        //public async Task<ApiResponse<ApiContract.FeatureRulesWithId>> GetItemByIdAsync(int id)
        //{
        //    var item = await _featureRulesService.GetByIdAsync(id);
        //    var apiData = _mapper.Map<ApiContract.FeatureRulesWithId>(item);
        //    return new ApiResponse<ApiContract.FeatureRulesWithId>(apiData);
        //}

        [HttpGet("statuses")]
        public async Task<ApiListResponse<ApiContract.RequestOfWorkStatusItem>> GetRequestOfWorkStatuses()
        {
            var list = await _requestOfWorkService.GetStatusListAsync();
            var apiData = _mapper.Map<ApiContract.RequestOfWorkStatusItem[]>(list);
            return new ApiListResponse<ApiContract.RequestOfWorkStatusItem>(apiData);
        }

        [HttpGet("types")]
        public async Task<ApiListResponse<ApiContract.RequestOfWorkTypeItem>> GetRequestOfWorkTypes()
        {
            var list = await _requestOfWorkService.GetTypeListAsync();
            var apiData = _mapper.Map<ApiContract.RequestOfWorkTypeItem[]>(list);
            return new ApiListResponse<ApiContract.RequestOfWorkTypeItem>(apiData);
        }

        [HttpPost("statement-of-work")]
        public async Task<ApiResponse<Identity>> PostAsync([FromBody] ApiContract.StatementOfWorkForAdd requestOfWork)
        {
            var request = _mapper.Map<RequestModels.StatementOfWorkAddingRequest>(requestOfWork);
            var requestId = await _mediator.Send(request);
            return new ApiResponse<Identity>(new Identity(requestId), "SOW successfully added");
        }

        [HttpPost("feature-definition-document")]
        public async Task<ApiResponse<Identity>> PostAsync([FromBody] ApiContract.FeatureDefinitionDocumentForAdd requestOfWork)
        {
            var request = _mapper.Map<RequestModels.FeatureDefinitionDocumentAddingRequest>(requestOfWork);
            var requestId = await _mediator.Send(request);
            return new ApiResponse<Identity>(new Identity(requestId), "FDD successfully added");
        }

        [HttpPost("fix-request")]
        public async Task<ApiResponse<Identity>> PostAsync([FromBody] ApiContract.FixRequestForAdd requestOfWork)
        {
            var request = _mapper.Map<RequestModels.FixRequestAddingRequest>(requestOfWork);
            var requestId = await _mediator.Send(request);
            return new ApiResponse<Identity>(new Identity(requestId), "FR successfully added");
        }

        //[HttpPut("{id}")]
        //public async Task PutAsync(int id, [FromBody] ApiContract.FeatureRules featureRules)
        //{
        //    var model = _mapper.Map<DomainModels.FeatureRules>(featureRules);
        //    model.Id = id;
        //    await _requestOfWorkService.ModifyAsync(model);
        //}

        //[HttpDelete("{id}")]
        //public async Task DeleteAsync(int id)
        //{
        //    await _requestOfWorkService.RemoveAsync(id);
        //}
    }
}
