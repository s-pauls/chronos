using System.Threading.Tasks;
using Chronos.Domain.Entities.Products;

namespace Chronos.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product[]> GetProducts(ProductFilter filter);
    }
}
