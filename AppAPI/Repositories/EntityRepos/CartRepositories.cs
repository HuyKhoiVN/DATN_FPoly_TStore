using AppAPI.DtoModels;
using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AppAPI.Repositories.EntityRepos
{
    public class CartRepositories : BaseRepository<Cart>, ICartRepository
    {

        public CartRepositories(TStoreDb context) : base(context)
        {
        }

        public async Task<Cart> GetCartDetailsByAccountIdAsync(Guid accountId)
        {
            var data = await _dbSet.Include(c => c.CartDetails).ThenInclude(cd => cd.ProductDetail).ThenInclude(pd => pd.Product).ThenInclude(p => p.Images)
                             .Include(c => c.CartDetails).ThenInclude(cd => cd.ProductDetail).ThenInclude(pd => pd.Size)
                             .Include(c => c.CartDetails).ThenInclude(cd => cd.ProductDetail).ThenInclude(pd => pd.Color)
                             .Where(c => c.IdAccount == accountId).FirstOrDefaultAsync();
            return data;
        }

        /// <summary>
        /// Tìm Cart theo accountId, nếu cart.CartDetails = null sẽ tạo mới
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// </returns>
        public async Task<Cart> GetCartByUserIdAsync(Guid userId)
        {
            // Sử dụng Eager Loading lấy ra Cart
            var cart = await _dbSet.Include(c => c.CartDetails)
                           .FirstOrDefaultAsync(c => c.IdAccount == userId);

            // Xử lý null cho CartDetails
            if (cart != null && cart.CartDetails == null)
            {
                cart.CartDetails = new List<CartDetail>();
            }

            return cart;
        }

        
    }
}
