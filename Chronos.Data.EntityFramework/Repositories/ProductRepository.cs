using System;
using System.Threading.Tasks;
using Chronos.Domain.Entities;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<int> AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
