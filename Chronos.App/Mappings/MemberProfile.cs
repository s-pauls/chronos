using AutoMapper;
using DomainModels = Chronos.Domain.Entities.Members;
using ApiContract = Chronos.App.DataContracts.Members;

namespace Chronos.App.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<DomainModels.Member, ApiContract.Member>();
            CreateMap<ApiContract.MemberQuery, DomainModels.MemberFilter>();
        }
    }
}
