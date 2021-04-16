using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chronos.App.DataContracts;
using Chronos.Core.Estimates;
using Chronos.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiContract = Chronos.App.DataContracts.Estimates;

namespace Chronos.App.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Components.Route("api/requests-of-work")]
    [ApiController]
    public class RequestsOfWorkEstimatesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEstimateService _estimateService;

        public RequestsOfWorkEstimatesController(
            IMapper mapper,
            IMediator mediator,
            IEstimateService estimateService
            )
        {
            _mapper = mapper;
            _mediator = mediator;
            _estimateService = estimateService;
        }

        [HttpGet("{requestOfWorkId:int}/estimates")]
        public async Task<ApiListResponse<ApiContract.Estimate>> GetListAsync([FromRoute] int requestOfWorkId)
        {
            var list = await _estimateService.GetListAsync(requestOfWorkId);
            var apiData = _mapper.Map<ApiContract.Estimate[]>(list);
            return new ApiListResponse<ApiContract.Estimate>(apiData);
        }

        [HttpPost("{requestOfWorkId:int}/estimates/{estimateTemplateId:int}"), DisableRequestSizeLimit]
        public async Task<IActionResult> PostAsync([FromRoute] int requestOfWorkId, [FromRoute] int estimateTemplateId, IFormFile file)
        {
            if (file.Length > 0)
            {
                var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

                if (!Directory.Exists(tempDirectory))
                {
                    Directory.CreateDirectory(tempDirectory);
                }

                var tempFileName = Path.Combine(tempDirectory, file.FileName);
                FileStream stream = null;
                try
                {
                    stream = new FileStream(tempFileName, FileMode.CreateNew);

                    file.CopyTo(stream);

                    await _mediator.Publish(new EstimateFromExcelAddingRequest
                    {
                        FilePath = tempFileName,
                        RequestOfWorkId = requestOfWorkId,
                        EstimateTemplateId = estimateTemplateId
                    });
                }
                finally
                {
                    if (stream != null)
                    {
                        await stream.DisposeAsync();
                    }

                    if (System.IO.File.Exists(tempFileName))
                    {
                        System.IO.File.Delete(tempFileName);
                    }
                }

                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{requestOfWorkId:int}/estimates/{estimateId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int requestOfWorkId, [FromRoute] int estimateId)
        {
            await _estimateService.RemoveAsync(estimateId);
            return NoContent();
        }
    }
}
