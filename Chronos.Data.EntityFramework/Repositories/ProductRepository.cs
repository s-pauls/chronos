using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chronos.Data.EntityFramework.Entities;
using Chronos.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Chronos.Data.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ChronosDbContext _dbContext;

        public ProductRepository(
            ChronosDbContext dbContext
             )
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProducts(ProductFilter filter)
        {
            var query = _dbContext.Products.AsQueryable();

            if (filter != null)
            {
                if (filter.Enabled.HasValue)
                {
                    query = query.Where(x => x.Enabled == filter.Enabled.Value);
                }
            }

            return await query.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                ProjectName = x.ProjectName,
                Enabled = x.Enabled
            }).ToListAsync();
        }

    }
}
