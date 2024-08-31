using AppAPI.DtoModels;
using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByCategoryId(Guid categoryId);
        
        Task<Product?> GetProductDetailInfo(Guid productId);
    }
}
