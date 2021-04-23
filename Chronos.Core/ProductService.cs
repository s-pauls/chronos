using System.Linq;
using System.Threading.Tasks;
using Chronos.Domain.Entities.Products;
using Chronos.Domain.Interfaces;
using Organization.WebApi.Client.Products;
using DomainModels = Chronos.Domain.Entities.Products;

namespace Chronos.Core
{
    public class ProductService : IProductService
    {
        private readonly IProductsClient _productsClient;

        public ProductService(
            IProductsClient productsClient)
        {
            _productsClient = productsClient;
        }

        public async Task<Product[]> GetProducts(ProductFilter filter)
        {
            var products = await _productsClient.GetProductsAsync();

            return products.Select(x => new DomainModels.Product
            {
                Uid = x.Uid,
                Name = x.ProductName,
                ProjectUid = x.ProjectUid,
                ProjectName = x.ProjectName,
                ProjectAdoName = x.ProjectAdoName,
                Enabled = x.Enabled
            }).ToArray();
        }

    }
}
