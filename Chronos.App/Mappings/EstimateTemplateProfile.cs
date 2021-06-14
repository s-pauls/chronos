using AutoMapper;
using DomainModels = Chronos.Domain.Entities.EstimateTemplates;
using ApiContract = Chronos.App.DataContracts.EstimateTemplates;

namespace Chronos.App.Mappings
{
    public class EstimateTemplateProfile : Profile
    {
        public EstimateTemplateProfile()
        {
            CreateMap<DomainModels.EstimateTemplate, ApiContract.EstimateTemplate>();

            CreateMap<DomainModels.EstimateTemplate, ApiContract.EstimateTemplateWithId>();

            CreateMap<DomainModels.EstimateTemplateTask, ApiContract.EstimateTemplateTask>();

            CreateMap<DomainModels.EstimateTemplateItem, ApiContract.EstimateTemplateItem>();

            CreateMap<DomainModels.EstimateTemplateGeneralValue, ApiContract.EstimateTemplateGeneralValue>();
        }
    }
}
