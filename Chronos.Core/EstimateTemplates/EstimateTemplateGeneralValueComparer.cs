using System;
using System.Collections.Generic;
using Chronos.Domain.Entities.EstimateTemplates;

namespace Chronos.Core.EstimateTemplates
{
    public class EstimateTemplateGeneralValueComparer : IEqualityComparer<EstimateTemplateGeneralValue>
    {
        public bool Equals(EstimateTemplateGeneralValue x, EstimateTemplateGeneralValue y)
        {
            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(EstimateTemplateGeneralValue obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
