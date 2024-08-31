using AppAPI.DtoModels;
using AppAPI.Service;
using AppAPI.Service.EntityInterface;
using AppData.Exceptions;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : TBaseController<Cart>
    {
        IBaseServices<Cart> _services;
        ICartService _cartService;
        public CartController(IBaseServices<Cart> baseServices, ICartService cartService) : base(baseServices)
        {
            _services = baseServices;
            _cartService = cartService;
        }

        /// <summary>
        /// Thêm sp vào giỏ hàng
        /// </summary>
        /// <param name="cartRequest"></param>
        /// <returns></returns>
        [HttpPost("addtocart")]
        public async Task<IActionResult> AddProductToCart([FromBody] CartRequestDto cartRequest)
        {
            try
            {
                var result = await _cartService.AddItemsToCart(cartRequest);
                if (result)
                    return Ok(new { message = "Product added to cart successfully" });
                return BadRequest(new { message = "Failed to add product to cart" });
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        /// <summary>
        /// Xoá sản phẩm khỏi giỏ hàng
        /// DELETE /api/cart/{accountId}/products/{productDetailId}
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="productDetailId"></param>
        /// <returns></returns>
        [HttpDelete("{accountId}/products/{productDetailId}")]
        public async Task<IActionResult> RemoveProductFromCart(Guid accountId, Guid productDetailId)
        {
            try
            {
                var result = await _cartService.RemoveItemFromCart(accountId, productDetailId);

                if (result)
                {
                    return Ok(new { message = "Product removed from cart successfully." });
                }
                else
                {
                    return NotFound(new { message = "Product or Cart not found." });
                }
            }
            catch (ValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.Data
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException
                };
                return StatusCode(500, response);
            }
        }

        [HttpGet("details/{accountId}")]
        public async Task<IActionResult> GetCartDetailsByAccountIdAsync(Guid accountId)
        {
            try
            {
                var cartDetails = await _cartService.GetCartDetailsByAccountIdAsync(accountId);
                if (cartDetails == null)
                {
                    return NotFound("Cart not found");
                }
                return Ok(cartDetails);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
