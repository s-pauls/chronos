using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Products;

namespace Chronos.Data
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(ProductFilter filter);
    }
}
