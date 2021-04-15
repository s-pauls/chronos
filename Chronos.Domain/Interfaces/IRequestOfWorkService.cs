using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.RequestsOfWork;

namespace Chronos.Domain.Interfaces
{
    public interface IRequestOfWorkService
    {
        public Task<List<RequestOfWork>> GetListAsync(RequestOfWorkFilter filter);
        public Task<List<FeatureStatusItem>> GetStatusListAsync();
        public Task<RequestOfWork> GetByIdAsync(int id);
        public Task<int> AddAsync(FeatureDefinitionDocument requestOfWork);
        public Task<int> AddAsync(StatementOfWork requestOfWork);
        public Task<int> AddAsync(FixRequest requestOfWork);
        public Task ModifyAsync(RequestOfWork requestOfWork);
        public Task RemoveAsync(int id);
        Task<int> GetNextNumber();
    }
}
