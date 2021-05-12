using System.Threading.Tasks;
using Chronos.Domain.Entities.Azure;

namespace Chronos.Domain.Interfaces
{
    public interface IAzureWorkItemClient
    {
        Task<AzureWorkItem> GetAzureWorkItemAsync(int id, AzureSettings settings);

        Task<AzureStory> CreateUserStoryAsync(AzureStory story, AzureSettings settings);

        Task<AzureTask> CreateTaskAsync(AzureTask task, AzureSettings settings);
    }
}
