using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data.Seeder
{
    public class ProductSeeder
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly Random random = new Random();
        public ProductSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SeedProducts()
        {
            // Get an instance of ApplicationDbContext from the service locator
            using (var scope = _serviceProvider.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (_dbContext.Products.Any()) { return; }
                var products = new List<Domain.Entities.Product>();

                // Generate or set the data for the products
                for (int i = 1; i <= 15; i++)
                {
                    string name = $"Product {i}";
                    string barCode = GenerateRandomBarCode(10);
                    string categoryName = $"Category {i}";
                    string description = $"Description {i}";
                    bool weighted = (i % 2 == 0); // Alternate between true and false
                    ProductStatus status = (i % 3 == 0) ? ProductStatus.Sold : ((i % 2==0) ? ProductStatus.Damaged : ProductStatus.InStock);

                    Domain.Entities.Product product = new(name, barCode, categoryName, description, weighted, status, DateTime.Now, DateTime.MinValue, "N/A", "Admin", 0);
                    products.Add(product);
                }

                _dbContext.AddRange(products);
                _dbContext.SaveChanges();
            }
            // Add more sample products as needed
            Console.WriteLine("Products seeded successfully.");
        }

        private static string GenerateRandomBarCode(int length)
        {
            StringBuilder barcodeBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int randomNumber = random.Next(0, 10);
                barcodeBuilder.Append(randomNumber);
            }

            return barcodeBuilder.ToString();
        }
    }
}
