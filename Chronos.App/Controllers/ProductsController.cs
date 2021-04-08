using System.Linq;
using System.Threading.Tasks;
using Chronos.App.DataContracts;
using Chronos.Domain.Entities.Products;
using Chronos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chronos.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ApiListResponse<DataContracts.Product>> GetProducts()
        {
            var products = await _productService.GetProducts(new ProductFilter { Enabled = true });
            var apiData = products.Select(product => new DataContracts.Product
            {
                Id = product.Id,
                Name = product.Name
            }).ToArray();
            return new ApiListResponse<DataContracts.Product>(apiData);
        }
    }
}
