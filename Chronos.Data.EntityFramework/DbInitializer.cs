using System.Linq;
using Chronos.Data.EntityFramework.Entities;

namespace Chronos.Data.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(ChronosDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new ProductEntity[]
            {
                new ProductEntity{Name = "Chronos", ProjectName = "Chronos", Enabled = true},
                new ProductEntity{Name = "ABP", ProjectName = "Chronos", Enabled = true},
                new ProductEntity{Name = "CDB", ProjectName = "Chronos", Enabled = true},
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
