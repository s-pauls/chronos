using System.Collections.Generic;
using Chronos.Domain.Entities.Products;
using System.Threading.Tasks;

namespace Chronos.Domain.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts(ProductFilter filter);
    }
}
