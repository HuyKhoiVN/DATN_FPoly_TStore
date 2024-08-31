using AppAPI.Repositories.EntityInterface;
using AppData.Context;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositories.EntityRepos
{
    public class ProductRepositories : BaseRepository<Product>, IProductRepository
    {
        public ProductRepositories(TStoreDb context) : base(context)
        {
        }

        /// <summary>
        /// Lấy danh sách sản phẩm theo categoryId
        /// </summary>
        /// <param name="categoryId">Id của ProductCategory</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductByCategoryId(Guid categoryId)
        {
            var data = await _dbSet.Where(p => p.IdProductCategory == categoryId).ToListAsync();
            return data;
        }

        public async Task<Product?> GetProductDetailInfo(Guid productId)
        {
            /*Lấy ra product cần hiển thị thông tin
               - Name - product
               - Images - product, lấy tất cả Imags từ bảng Images mà có productId = product.Id
               - Rate - product
               - Price - product
               - Description - product
               - Size, Color, Quantity - productDetail
               - Lấy tất cả productDetail từ bảng productDetail mà productId = product.Id, từ đó lấy ra Quantity, IdSize, IdColor của từng productDetail
               - Từ IdSize, IdColor lấy được SizeName, ColorName
             */
            return await _dbSet.Include(p => p.Images)
                               .Include(P => P.ProductDetails).ThenInclude(pd => pd.Size)
                               .Include(p => p.ProductDetails).ThenInclude(pd => pd.Color)
                               .FirstOrDefaultAsync(p => p.Id == productId);
        }
    }
}
