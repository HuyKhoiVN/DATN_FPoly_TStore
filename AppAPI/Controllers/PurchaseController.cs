using AppAPI.DtoModels;
using AppAPI.Service.EntityInterface;
using AppData.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// API mua hàng trực tiếp
        /// </summary>
        /// <param name="purchaseRequestDto">Dto mua hàng FromBody</param>
        /// <returns>
        /// 200 - Success,
        /// 400 - ValidateEx,
        /// 500 - Ex
        /// </returns>
        [HttpPost("purchase")]
        public async Task<IActionResult> BuyProduct([FromBody] PurchaseRequestDto purchaseRequestDto)
        {
            try
            {
                // Gọi BuyProduct từ Service
                var billDto = await _purchaseService.BuyProduct(purchaseRequestDto);

                // Thành công trả về OK (200/201)
                return Ok(billDto);
            }
            catch (ValidateException ex)
            {
                // 400 BadRequest nếu có lỗi ValidateException
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Với lỗi khác trả về 500 InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        /// <summary>
        /// API mua hàng từ cart
        /// </summary>
        /// <param name="purchaseRequestDto">Dto mua hàng FromBody</param>
        /// <returns>
        /// 200 - Success,
        /// 400 - ValidateEx,
        /// 500 - Ex
        /// </returns>
        [HttpPost("purchase-from-cart")]
        public async Task<IActionResult> BuyProductsFromCart([FromBody] PurchaseRequestDto purchaseRequestDto)
        {
            try
            {
                // Gọi hàm BuyProductsFromCart từ service để xử lý logic mua hàng từ giỏ hàng
                var billDto = await _purchaseService.BuyProductsFromCart(purchaseRequestDto);

                // Trả về kết quả thành công với BillDto
                return Ok(billDto);
            }
            catch (ValidateException ex)
            {
                // Xử lý lỗi validate và trả về mã lỗi 400 BadRequest
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi khác và trả về mã lỗi 500 InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

    }
}
