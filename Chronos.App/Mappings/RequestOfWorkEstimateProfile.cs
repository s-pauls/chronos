using AutoMapper;
using DomainModels = Chronos.Domain.Entities.Estimate;
using ApiContract = Chronos.App.DataContracts.Estimates;

namespace Chronos.App.Mappings
{
    public class RequestOfWorkEstimateProfile : Profile
    {
        public RequestOfWorkEstimateProfile()
        {
            CreateMap<DomainModels.Estimate, ApiContract.Estimate>()
                .ForMember(x => x.EstimateId, opt => opt.MapFrom(src => src.Id));

            CreateMap<DomainModels.EstimateTemplate, ApiContract.EstimateTemplate>();
        }
    }
}
