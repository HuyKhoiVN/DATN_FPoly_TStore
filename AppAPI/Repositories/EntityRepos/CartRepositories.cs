using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;

namespace AppAPI.Repositories.EntityRepos
{
    public class CartRepositories : BaseRepository<Cart>, ICartRepository
    {
        private readonly TStoreDb _dbContext;
        public CartRepositories(TStoreDb context) : base(context)
        {
            _dbContext = context;
        }

        public Task AddItemToCartAsync(Guid userId, CartDetail item)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromCartAsync(Guid userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemQuantityAsync(Guid userId, Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
