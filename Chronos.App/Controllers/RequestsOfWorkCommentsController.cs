using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.AuditLogs;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiContract = Chronos.App.DataContracts.Comments;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Route("api/requests-of-work")]
    [ApiController]
    public class RequestsOfWorkCommentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuditLogService _auditLogService;

        public RequestsOfWorkCommentsController(
            IMapper mapper,
            IAuditLogService auditLogService
            )
        {
            _mapper = mapper;
            _auditLogService = auditLogService;
        }

        [HttpGet("{requestOfWorkId:int}/comments")]
        public async Task<ApiListResponse<ApiContract.Comment>> GetListAsync([FromRoute] int requestOfWorkId)
        {
            var list = await _auditLogService.GetListAsync(new AuditLogFilter
            {
                ChronosObjects = ChronosObject.RequestOfWork,
                ChronosObjectId = requestOfWorkId
            });
            var apiData = _mapper.Map<ApiContract.Comment[]>(list);
            return new ApiListResponse<ApiContract.Comment>(apiData);
        }

        [HttpPost("{requestOfWorkId:int}/comments")]
        public async Task<IActionResult> PostAsync([FromRoute] int requestOfWorkId, [FromBody] ApiContract.CommentForInput comment)
        {
            await _auditLogService.AddCustomAsync(comment.Message, requestOfWorkId, ChronosObject.RequestOfWork);
            return NoContent();
        }

        [HttpPut("{requestOfWorkId:int}/comments/{commentId}")]
        public async Task<IActionResult> PutAsync(int commentId, [FromBody] ApiContract.CommentForInput comment)
        {
            await _auditLogService.ModifyCustomMessageAsync(commentId, comment.Message);
            return NoContent();
        }

        [HttpDelete("{requestOfWorkId:int}/comments/{commentId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int requestOfWorkId, [FromRoute] int commentId)
        {
            await _auditLogService.RemoveCustomAsync(commentId);
            return NoContent();
        }
    }
}
