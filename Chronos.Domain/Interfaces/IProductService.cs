using System.Threading.Tasks;
using Chronos.Domain.Entities;

namespace Chronos.Domain.Interfaces
{
    public interface IProductService
    {
        public Task<int> AddProduct(Product product);
    }
}
