using System;
using AutoMapper;

namespace Chronos.App.Mappings
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<DateTime, DateTime>()
                .ConvertUsing<DateTimeTypeConverter>();
        }
    }
}
