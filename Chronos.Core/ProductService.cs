using System.Collections.Generic;
using System.Threading.Tasks;
using Chronos.Data;
using Chronos.Domain.Entities.Products;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts(ProductFilter filter)
        {
            return await _productRepository.GetProducts(filter);
        }

    }
}
