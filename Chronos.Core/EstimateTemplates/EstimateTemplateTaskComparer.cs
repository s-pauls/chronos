using System;
using System.Collections.Generic;
using Chronos.Domain.Entities.EstimateTemplates;

namespace Chronos.Core.EstimateTemplates
{
    public class EstimateTemplateTaskComparer : IEqualityComparer<EstimateTemplateTask>
    {
        public bool Equals(EstimateTemplateTask x, EstimateTemplateTask y)
        {
            return string.Equals(x.TaskName, y.TaskName, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(EstimateTemplateTask obj)
        {
            return obj.TaskName.GetHashCode();
        }
    }
}
