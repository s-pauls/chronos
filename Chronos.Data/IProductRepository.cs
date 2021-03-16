using Chronos.Domain;
using System.Threading.Tasks;
using Chronos.Domain.Entities;

namespace Chronos.Data
{
    public interface IProductRepository
    {
        Task<int> AddProduct(Product product);
    }
}
