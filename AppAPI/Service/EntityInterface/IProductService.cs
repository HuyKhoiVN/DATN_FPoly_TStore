using AppAPI.DtoModels;
using AppData.Models;

namespace AppAPI.Service.EntityInterface
{
    public interface IProductService : IBaseServices<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
        Task<ProductDetailDto?> GetProductDetailInfo(Guid productId);
    }
}
