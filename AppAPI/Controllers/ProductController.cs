using AppAPI.Service;
using AppAPI.Service.EntityInterface;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : TBaseController<Product>
    {
        IBaseServices<Product> _services;
        IProductService _productService;
        public ProductController(IBaseServices<Product> baseServices, IProductService productService) : base(baseServices)
        {
            _services = baseServices;
            _productService = productService;
        }

        // Lấy product theo category
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory(Guid categoryId)
        {
            try
            {
                // Gọi service
                var data = await _productService.GetProductsByCategory(categoryId);

                // Xử lý null
                if(data == null || !data.Any())
                {
                    return NotFound("No products found for the given category");
                }

                // Trả về ds
                return Ok(data);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = "An error occurred while retrieving the products.",
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        // Lấy productDetailInfo
        [HttpGet("productDetail/{productId:guid}")]
        public async Task<IActionResult> GetProductDetail(Guid productId)
        {
            var productDetail = await _productService.GetProductDetailInfo(productId);

            if (productDetail == null)
                return NotFound();

            return Ok(productDetail);
        }
    }
}
