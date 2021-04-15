using System.Collections.Generic;
using System.Linq;

namespace Chronos.Utilities.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool NotNullAndAny<T>(this IEnumerable<T> enumeration)
        {
            if (enumeration == null)
            {
                return false;
            }

            return enumeration.Any();
        }
    }
}
