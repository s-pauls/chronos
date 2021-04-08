using System.Threading.Tasks;
using Chronos.Domain.Entities.Azure;
using Chronos.Domain.Entities.Blank;
using Chronos.Domain.Entities.FeatureRules;

namespace Chronos.Domain.Interfaces
{
    public interface IWorkItemService
    {
        Task CreateWorkItemsAsync(BlankFeature feature, FeatureRules featureRules, AzureSettings settings);
    }
}
