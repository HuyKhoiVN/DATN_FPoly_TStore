using AppData.Models;

namespace AppAPI.Repositories.EntityInterface
{
    public interface IProductDetailRepository : IBaseRepository<ProductDetail>
    {
        Task<ProductDetail> GetProduct(Guid productId);
    }
}
