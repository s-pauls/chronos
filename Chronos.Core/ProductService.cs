using Chronos.Data;
using Chronos.Domain;
using System.Threading.Tasks;
using Chronos.Domain.Entities;
using Chronos.Domain.Interfaces;

namespace Chronos.Core
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public ProductService(
            IProductRepository productRepository,
            IAuditLogRepository auditLogRepository)
        {
            _productRepository = productRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<int> AddProduct(Product product)
        {
            var productId = await _productRepository.AddProduct(product);
            _auditLogRepository.Add(userId: 3, $"{product.Name} was added");
            return productId;
        }
    }
}
