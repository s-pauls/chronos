using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.RequestsOfWork;

namespace Chronos.Domain.Interfaces
{
    public interface IRequestOfWorkService
    {
        Task<List<RequestOfWork>> GetListAsync(RequestOfWorkFilter filter);
        Task<List<RequestOfWorkStatusItem>> GetStatusListAsync();
        Task<List<RequestOfWorkTypeItem>> GetTypeListAsync();
        Task<RequestOfWork> GetByIdAsync(int id);
        Task<int> AddAsync(FeatureDefinitionDocument requestOfWork);
        Task<int> AddAsync(StatementOfWork requestOfWork);
        Task<int> AddAsync(FixRequest requestOfWork);
        Task ModifyAsync(RequestOfWork requestOfWork);
        Task RemoveAsync(int id);
        Task<int> GetNextNumber();
    }
}
