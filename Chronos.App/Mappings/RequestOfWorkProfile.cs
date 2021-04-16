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
            CreateMap<DomainModels.RequestOfWorkStatusItem, ApiContract.RequestOfWorkStatusItem>();
            CreateMap<DomainModels.RequestOfWorkTypeItem, ApiContract.RequestOfWorkTypeItem>();

            CreateMap<ApiContract.RequestOfWorkQuery, DomainModels.RequestOfWorkFilter>()
                .ForMember(d => d.Ids, o => o.MapFrom(s => s.RequestOfWorkId))
                .ForMember(d => d.Statuses, o => o.MapFrom(s => s.StatusId))
                .ForMember(d => d.RequestOfWorkTypes, o => o.MapFrom(s => s.TypeId))
                .ForMember(d => d.Products, o => o.MapFrom(s => s.ProductId));

            CreateMap<DomainModels.RequestOfWork, ApiContract.RequestOfWork>()
                .ForMember(d => d.RequestOfWorkId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.StatusId, o => o.MapFrom(s => s.Status));

            CreateMap<ApiContract.StatementOfWorkForAdd, StatementOfWorkAddingRequest>(MemberList.Source);
            CreateMap<ApiContract.FeatureDefinitionDocumentForAdd, FeatureDefinitionDocumentAddingRequest>(MemberList.Source);
            CreateMap<ApiContract.FixRequestForAdd, FixRequestAddingRequest>(MemberList.Source);

        }
    }
}
