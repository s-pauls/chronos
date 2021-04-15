using System.Collections.Generic;
using Chronos.Domain.Entities.Products;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(ProductFilter filter);
    }
}
