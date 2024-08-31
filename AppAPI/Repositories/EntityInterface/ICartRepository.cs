using AppAPI.DtoModels;
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
        Task<Cart> GetCartDetailsByAccountIdAsync(Guid accountId);
    }
}
