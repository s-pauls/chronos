using AutoMapper;
using DomainModels = Chronos.Domain.Entities.FeatureRules;
using ApiContract = Chronos.App.DataContracts.FeatureRules;

namespace Chronos.App.Mappings
{
    public class FeatureRulesProfile : Profile
    {
        public FeatureRulesProfile()
        {
            CreateMap<DomainModels.StoryRules, ApiContract.StoryRules>()
                .ReverseMap();

            CreateMap<DomainModels.TaskRules, ApiContract.TaskRules>()
                .ReverseMap();

            CreateMap<DomainModels.TitleVariable, ApiContract.TitleVariable>()
                .ReverseMap();

            CreateMap<DomainModels.FeatureRules, ApiContract.FeatureRulesWithId>();

            CreateMap<ApiContract.FeatureRules, DomainModels.FeatureRules>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ReverseMap();
        }
    }
}
