using AutoMapper;
using DomainModels = Chronos.Domain.Entities.AuditLogs;
using ApiContract = Chronos.App.DataContracts.Comments;

namespace Chronos.App.Mappings
{
    public class AuditLogProfile : Profile
    {
        public AuditLogProfile()
        {
            CreateMap<DomainModels.AuditLog, ApiContract.Comment>()
                .ForMember(d => d.CommentId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.DateTime, o => o.MapFrom(s => s.Date));
        }
    }
}
