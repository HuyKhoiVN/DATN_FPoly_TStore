using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        /// <summary>
        /// Lấy giỏ hàng theo UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Cart> GetCartByUserIdAsync(Guid userId);

        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="userId">Id của account, dùng để lấy ra Cart có accountId = userId</param>
        /// <param name="item">Thêm cart detail vào Cart</param>
        /// <returns></returns>
        Task AddItemToCartAsync(Guid userId, CartDetail item);

        /// <summary>
        /// Cập nhật số lượng của sp
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Task UpdateItemQuantityAsync(Guid userId, Guid productId, int quantity);

        /// <summary>
        /// Xoá sản phẩm khỏi giỏ hàng
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task RemoveItemFromCartAsync(Guid userId, Guid productId);
    }
}
