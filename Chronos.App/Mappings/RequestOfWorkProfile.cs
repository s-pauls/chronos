using AutoMapper;
using Chronos.Core.RequestsOfWork;
using DomainModels = Chronos.Domain.Entities.RequestsOfWork;
using ApiContract = Chronos.App.DataContracts.RequestsOfWork;

namespace Chronos.App.Mappings
{
    public class RequestOfWorkProfile : Profile
    {
        public RequestOfWorkProfile()
        {
            CreateMap<DomainModels.FeatureStatusItem, ApiContract.RequestOfWorkStatusItem>();

            CreateMap<ApiContract.RequestOfWorkQuery, DomainModels.RequestOfWorkFilter>()
                .ForMember(d => d.Ids, o => o.MapFrom(s => s.RequestOfWorkId))
                .ForMember(d => d.Statuses, o => o.MapFrom(s => s.StatusId));

            CreateMap<DomainModels.RequestOfWork, ApiContract.RequestOfWork>()
                .ForMember(d => d.RequestOfWorkId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.StatusId, o => o.MapFrom(s => s.Status));

            CreateMap<ApiContract.StatementOfWorkForAdd, StatementOfWorkAddingRequest>(MemberList.Source);
            CreateMap<ApiContract.FeatureDefinitionDocumentForAdd, FeatureDefinitionDocumentAddingRequest>(MemberList.Source);
            CreateMap<ApiContract.FixRequestForAdd, FixRequestAddingRequest>(MemberList.Source);

        }
    }
}
