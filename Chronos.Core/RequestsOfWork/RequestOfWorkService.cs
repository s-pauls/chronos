using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities;
using Chronos.Domain.Entities.AuditLogs;
using Chronos.Domain.Entities.RequestsOfWork;
using Chronos.Domain.Enums;
using Chronos.Domain.Interfaces;

namespace Chronos.Core.RequestsOfWork
{
    public class RequestOfWorkService : IRequestOfWorkService
    {
        private readonly IRequestOfWorkRepository _requestOfWorkRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public RequestOfWorkService(
            IRequestOfWorkRepository requestOfWorkRepository,
            IAuditLogRepository auditLogRepository
        )
        {
            _requestOfWorkRepository = requestOfWorkRepository;
            _auditLogRepository = auditLogRepository;
        }


        public async Task<List<RequestOfWork>> GetListAsync(RequestOfWorkFilter filter)
        {
            var list = await _requestOfWorkRepository.GetListAsync(filter);
            list.ForEach(x => x.StatusName = GetStatusName(x.Status));
            return list;
        }

        public async Task<List<RequestOfWorkStatusItem>> GetStatusListAsync()
        {
            var list = Enum.GetValues(typeof(RequestOfWorkStatus))
                .Cast<RequestOfWorkStatus>()
                .Select(x => new RequestOfWorkStatusItem
                {
                    Id = (int)x,
                    Name = GetStatusName(x)
                })
                .ToList();

            return await Task.FromResult(list);
        }

        public async Task<List<RequestOfWorkTypeItem>> GetTypeListAsync()
        {
            var list = Enum.GetValues(typeof(RequestOfWorkType))
                .Cast<RequestOfWorkType>()
                .Select(x => new RequestOfWorkTypeItem
                {
                    Id = (int)x,
                    Name = GetTypeName(x)
                })
                .ToList();

            return await Task.FromResult(list);
        }

        public async Task<RequestOfWork> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddAsync(FeatureDefinitionDocument requestOfWork)
        {
            var requestId = await _requestOfWorkRepository.AddAsync(requestOfWork);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ChronosObject = ChronosObject.RequestOfWork,
                ChronosObjectId = requestId,
                Date = DateTime.UtcNow,
                Message = "The FDD created",
                UserId = 1 // todo
            });
            return requestId;
        }

        public async Task<int> AddAsync(StatementOfWork requestOfWork)
        {
            var requestId = await _requestOfWorkRepository.AddAsync(requestOfWork);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ChronosObject = ChronosObject.RequestOfWork,
                ChronosObjectId = requestId,
                Date = DateTime.UtcNow,
                Message = "The SOW created",
                UserId = 1 // todo
            });
            return requestId;
        }

        public async Task<int> AddAsync(FixRequest requestOfWork)
        {
            var requestId = await _requestOfWorkRepository.AddAsync(requestOfWork);
            await _auditLogRepository.AddAsync(new AuditLog
            {
                ChronosObject = ChronosObject.RequestOfWork,
                ChronosObjectId = requestId,
                Date = DateTime.UtcNow,
                Message = "The FR created",
                UserId = 1 // todo
            });
            return requestId;
        }

        public async Task ModifyAsync(RequestOfWork requestOfWork)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> GetNextNumber()
        {
            var maxNumber = await _requestOfWorkRepository.GetMaxNumber();
            return ++maxNumber;
        }

        private string GetStatusName(RequestOfWorkStatus status)
        {
            switch (status)
            {
                case RequestOfWorkStatus.NotSentToCSI:
                    return Labels.RequestOfWorkStatus_NotSentToCSI;
                case RequestOfWorkStatus.NotStarted:
                    return Labels.RequestOfWorkStatus_NotStarted;
                case RequestOfWorkStatus.InProgress:
                    return Labels.RequestOfWorkStatus_InProgress;
                case RequestOfWorkStatus.Blocked:
                    return Labels.RequestOfWorkStatus_Blocked;
                case RequestOfWorkStatus.OnHold:
                    return Labels.RequestOfWorkStatus_OnHold;
                case RequestOfWorkStatus.SentToWEX:
                    return Labels.RequestOfWorkStatus_SentToWEX;
                case RequestOfWorkStatus.Approved:
                    return Labels.RequestOfWorkStatus_Approved;
                case RequestOfWorkStatus.Removed:
                    return Labels.RequestOfWorkStatus_Removed;
                case RequestOfWorkStatus.Released:
                    return Labels.RequestOfWorkStatus_Released;
                case RequestOfWorkStatus.ReleasedNotReproducible:
                    return Labels.RequestOfWorkStatus_ReleasedNotReproducible;
                case RequestOfWorkStatus.ReleasedReproducible:
                    return Labels.RequestOfWorkStatus_ReleasedReproducible;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        private string GetTypeName(RequestOfWorkType requestOfWorkType)
        {
            switch (requestOfWorkType)
            {
                case RequestOfWorkType.FeatureDefinitionDocument:
                    return Labels.RequestOfWorkType_FeatureDefinitionDocument;
                case RequestOfWorkType.StatementOfWork:
                    return Labels.RequestOfWorkType_StatementOfWork;
                case RequestOfWorkType.FixRequest:
                    return Labels.RequestOfWorkType_FixRequest;
                default:
                    throw new ArgumentOutOfRangeException(nameof(requestOfWorkType), requestOfWorkType, null);
            }
        }
    }

}