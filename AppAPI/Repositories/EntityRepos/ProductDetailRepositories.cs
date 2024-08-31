using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class ProductDetailRepositories : BaseRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepositories(TStoreDb context) : base(context)
        {
        }

        public async Task<ProductDetail> GetProduct(Guid productId)
        {
            return await _dbSet.Include(c => c.Product).FirstOrDefaultAsync(p => p.IdProduct == productId);
        }
    }
}
