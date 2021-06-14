using System;
using System.Collections.Generic;
using Chronos.Domain.Entities.EstimateTemplates;

namespace Chronos.Core.EstimateTemplates
{
    public class EstimateTemplateItemComparer : IEqualityComparer<EstimateTemplateItem>
    {
        public bool Equals(EstimateTemplateItem x, EstimateTemplateItem y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) == 0
                   && x.Discipline == y.Discipline;
        }

        public int GetHashCode(EstimateTemplateItem obj)
        {
            return HashCode.Combine(obj.Name, obj.Discipline);
        }
    }
}
