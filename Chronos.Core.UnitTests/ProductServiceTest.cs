using Chronos.Data;
using Chronos.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Chronos.Core.UnitTests
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Mock<IAuditLogRepository> _auditLogRepositoryMock = new Mock<IAuditLogRepository>();
        private readonly ProductService _productService;

        public ProductServiceTest()
        {
            _productRepositoryMock
                .Setup(repository => repository.AddProduct(It.IsAny<Product>()))
                .ReturnsAsync(1);

            _productService = new ProductService(_productRepositoryMock.Object, _auditLogRepositoryMock.Object);
        }

        [Fact]
        public async Task AddProduct_NewProduct_ProductId()
        {
            var productId = await _productService.AddProduct(new Product());
            Assert.True(productId > 0);
        }
    }
}
