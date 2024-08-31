using AppAPI.DtoModels;
using AppAPI.Repositories;
using AppAPI.Repositories.EntityInterface;
using AppAPI.Service.EntityInterface;
using AppData.Exceptions;
using AppData.Models;

namespace AppAPI.Service.EntityServices
{
    public class CartService : BaseServices<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IBaseRepository<Product> _productRepository;
        public CartService(IBaseRepository<Cart> repository, IBaseRepository<Product> productRepository, IProductDetailRepository productDetailRepository, ICartRepository cartRepository) : base(repository)
        {
            _cartRepository = cartRepository;
            _productDetailRepository = productDetailRepository;
            _productRepository = productRepository;
        }

            /*
             * Nghiệp vụ:
             * 1. Lấy ra Cart có id = accountId, trường hợp k có => tạo mới
             * 2. Lấy ra CartDetail trong Cart mà productDetailId = tham số đầu vào
             * 3.1 Nếu tồn tại CartDetail => tăng số lượng
             * 3.2 Không tồn tại CartDetail => tạo mới CartDetail trong Cart với sô lượng đầu vào
             * 4. Cập nhật cart với cartDetail và id của cart
             */

        public async Task<CartDto> GetCartDetailsByAccountIdAsync(Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                throw new ValidateException("Account ID cannot be empty");
            }

            var cart = await _cartRepository.GetCartDetailsByAccountIdAsync(accountId);
            if (cart == null)
                throw new ValidateException("Cart null or not found");

            var cartDetails = cart.CartDetails;
            if (cartDetails == null)
            {
                cartDetails = new List<CartDetail>();
            }

            var cartDto = new CartDto
            {
                CartId = cart.Id,
                AccountId = cart.IdAccount,
                CartDetails = cartDetails.Select(cd => new CartDetailDto
                {
                    ProductName = cd.ProductDetail?.Product?.Name ?? string.Empty,
                    ImageUrl = cd.ProductDetail?.Product?.Images?.FirstOrDefault()?.ImageUrl ?? string.Empty,
                    OriginalPrice = cd.OriginalPrice,
                    SalePrice = cd.SalePrice,
                    SizeName = cd.ProductDetail?.Size?.SizeName ?? string.Empty,
                    ColorName = cd.ProductDetail?.Color?.ColorName ?? string.Empty,
                    Quantity = cd.ProductQuantity
                }).ToList()
            };
            return cartDto;
        }
        public async Task<bool> AddItemsToCart(CartRequestDto cartRequest)
        {
            // 1. Lấy ra cart, bao gồm các thông tin về cart.CartDetails theo accountId
            var cart = await _cartRepository.GetCartDetailsByAccountIdAsync(cartRequest.AccountId);

            // Lấy ra productDetail theo Id
            var productDetail = await _productDetailRepository.GetByIdAsync(cartRequest.ProductDetailId);
            if (productDetail == null)
                throw new ValidateException($"product detail is null with id {cartRequest.ProductDetailId}");

            if (cartRequest.Quantity <= 0 || cartRequest.Quantity > productDetail.Quantity)
            {
                throw new ValidateException("Quantity must be greater than zero and quantity available");
            }

            // 2. Lấy ra Cart
            // Nếu cart null -> tạo mới Cart
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    IdAccount = cartRequest.AccountId,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    Status = true,
                    CartDetails = new List<CartDetail>()
                };
                await _cartRepository.CreateAsync(cart);
            }
            // 3. Lấy ra cartDetail của cart
            var cartDetails = cart.CartDetails;

            // Xử lý null cho cartDetails
            if (cartDetails == null)
            {
                cartDetails = new List<CartDetail>();
            }

            // 4. Lấy ra cartDetailItem chứa IdProductDetail
            var exitCartDetail = cartDetails.FirstOrDefault(pd => pd.IdProductDetail == cartRequest.ProductDetailId);
            // 4.1 Cập nhật số lượng nếu tồn tại
            if(exitCartDetail != null)
            {
                exitCartDetail.ProductQuantity += cartRequest.Quantity;
                exitCartDetail.ModifiedDate = DateTime.UtcNow;
                if (exitCartDetail.ProductQuantity > productDetail.Quantity)
                {
                    throw new ValidateException("Quantity exceeds available stock.");
                }
            }
            else // 4.2 Tạo mới nếu null
            {              
                var product = await _productRepository.GetByIdAsync(productDetail.IdProduct);
                if (product == null) 
                    throw new ValidateException($"product is null with id {productDetail.IdProduct}");

                exitCartDetail = new CartDetail
                {
                    Id = Guid.NewGuid(),
                    IdProductDetail = cartRequest.ProductDetailId,
                    IdCart = cart.Id,
                    OriginalPrice = product.Price,
                    SalePrice = product.Price,
                    ProductQuantity = cartRequest.Quantity,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };
                cartDetails.Add(exitCartDetail); // Thêm cartDetail vào CartDetails
            }

            // 5. Cập nhật lại cart sau khi đã thực hiện thêm sp
            /*var updateResult = await _cartRepository.UpdateAsync(cart.Id, cart);*/
            /*if (!updateResult)
            {
                throw new ValidateException("Failed to update cart.");
            }
            return true;*/

            var id = cart.Id;
            return await _cartRepository.UpdateAsync(id, cart);
        }

        public async Task<bool> RemoveItemFromCart(Guid accountId, Guid productDetailId)
        {
            var cart = await _cartRepository.GetCartDetailsByAccountIdAsync(accountId);
            if (cart == null)
            {
                return true;
            }

            var cartDetails = cart.CartDetails;
            if (cartDetails == null)
            {
                return true;
            }
            
            var cartDetail = cartDetails.FirstOrDefault(cd => cd.IdProductDetail == productDetailId);
            if (cartDetail == null)
            {
                throw new ValidateException($"[From CartDetails] - NOT FOUND cartDetail with productDetail id {productDetailId}");
            }

            cartDetails.Remove(cartDetail);

            if (!cartDetails.Any())
            {
                await _cartRepository.DeleteAsync(cart.Id);
                return true;
            }

            await _cartRepository.UpdateAsync(cart.Id, cart);
            return true;
        }
    }
}
