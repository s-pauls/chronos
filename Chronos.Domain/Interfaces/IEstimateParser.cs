using System.Collections.Generic;
using Chronos.Domain.Entities.Estimate;

namespace Chronos.Domain.Interfaces
{
    public interface IEstimateParser
    {
        List<EstimateItem> Parse(string filePath);
    }
}
