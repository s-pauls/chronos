using System;
using AutoMapper;

namespace Chronos.App.Mappings
{
    public class DateTimeTypeConverter : ITypeConverter<DateTime, DateTime>
    {
        public DateTime Convert(DateTime source, DateTime destination, ResolutionContext context)
        {
            if (source.Kind == DateTimeKind.Unspecified)
            {
                return DateTime.SpecifyKind(source, DateTimeKind.Utc);
            }

            return source;

        }
    }
}
