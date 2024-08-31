using AppAPI.DtoModels;
using AppData.Models;

namespace AppAPI.Service.EntityInterface
{
    public interface ICartService : IBaseServices<Cart>
    {       
        Task<CartDto> GetCartDetailsByAccountIdAsync(Guid accountId);
        Task<bool> AddItemsToCart(CartRequestDto cartRequest);
        Task<bool> RemoveItemFromCart(Guid accountId, Guid productDetailId);
    }
}
