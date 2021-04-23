using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DomainModels = Chronos.Domain.Entities.Members;
using ApiContract = Chronos.App.DataContracts.Members;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        private readonly IMapper _mapper;

        public MembersController(
            IMembersService membersService,
            IMapper mapper)
        {
            _membersService = membersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ApiListResponse<ApiContract.Member>> GetListAsync([FromQuery] ApiContract.MemberQuery query)
        {
            var filter = _mapper.Map<DomainModels.MemberFilter>(query);
            var list = await _membersService.GetMembers(filter);
            var apiData = _mapper.Map<ApiContract.Member[]>(list);
            return new ApiListResponse<ApiContract.Member>(apiData);
        }
    }
}
