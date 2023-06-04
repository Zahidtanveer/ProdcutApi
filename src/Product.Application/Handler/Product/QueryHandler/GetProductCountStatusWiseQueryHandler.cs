using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services.Product.QueryHandler
{


    public class GetProductCountStatusWiseQueryHandler : IProductQuery
    {
        private readonly IProductRepository _productRepository;
        public GetProductCountStatusWiseQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Dictionary<ProductStatus, int>> GetProductStatusWiseCountAsync()
        {
            // Status Wise Products Count
            var products = await _productRepository.GetAllAsync();
            Dictionary<ProductStatus, int> productCountByStatus = products
               .GroupBy(p => p.Status)
               .ToDictionary(g => g.Key, g => g.Count());

            return productCountByStatus;
        }
    }

    public interface IProductQuery
    {
        public Task<Dictionary<ProductStatus, int>> GetProductStatusWiseCountAsync();
    }

}
