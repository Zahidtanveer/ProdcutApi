using Microsoft.AspNetCore.Mvc;
using Product.Application.Services.Product.QueryHandler;
using Product.Domain.Commands.Product;
using Product.Domain.Interfaces;
using Product.Domain.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    /// <summary>
    /// Products
    /// </summary>
    [Route(ProductAPIEndPointNames.BaseURLControllerLevel)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandHandler<SellProductCommand> _sellProductCommandHandler;
        private readonly ICommandHandler<UpdateProductStatusCommand> _updateProductStatusCommandHandler;
        private readonly IProductQuery _productQuery;

        /// <summary>
        /// Product Constructor Activate Services 
        /// </summary>
        /// <param name="sellProductCommandHandler"></param>
        /// <param name="updateProductStatusCommandHandler"></param>
        /// <param name="productQuery"></param>
        public ProductController(ICommandHandler<SellProductCommand> sellProductCommandHandler, ICommandHandler<UpdateProductStatusCommand> updateProductStatusCommandHandler, IProductQuery productQuery)
        {
            _sellProductCommandHandler = sellProductCommandHandler;
            _updateProductStatusCommandHandler = updateProductStatusCommandHandler;
            _productQuery = productQuery;
        }

        /// <summary>
        /// Get All Product Count Status Wise
        /// </summary>
        /// <returns></returns>
        [HttpGet(ProductAPIEndPointNames.GetProductsCountStatusWise)]
        public IActionResult GetProductCountStatusWise()
        {
            return Ok(_productQuery.GetProductStatusWiseCountAsync().Result);
        }

        /// <summary>
        /// Update Product Status
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(ProductAPIEndPointNames.UpdateProductStatus)]
        public async Task<IActionResult> UpdateProductStatus(UpdateProductStatusCommand command)
        {
            var result =await _updateProductStatusCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result.Messages);

            return BadRequest(result.Messages);
        }

        /// <summary>
        /// Sell Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(ProductAPIEndPointNames.SellProdcut)]
        public async Task<IActionResult> SellProduct(SellProductCommand command)
        {
            var result =await _sellProductCommandHandler.Handle(command);

            if (result.Success)
                return Ok(result.Messages);

            return BadRequest(result.Messages);
        }
 }
}
