using Product.Infrastructure.Data.Seeder;

namespace Product.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// Application Builder Extension
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Seeder(this IServiceProvider serviceProvider)
        {
            var seeder = new ProductSeeder(serviceProvider);
            seeder.SeedProducts();
        }
    }
}
