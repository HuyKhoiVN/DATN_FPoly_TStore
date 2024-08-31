using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;

namespace AppAPI.Repositories.EntityRepos
{
    public class CartDetailRepositories : BaseRepository<CartDetail>, ICartDetailRepository
    {       
        public CartDetailRepositories(TStoreDb context) : base(context)
        {
        }
    }
}
