using AppAPI.DtoModels;

namespace AppAPI.Service.EntityInterface
{
    public interface IPurchaseService
    {
        Task<BillDto> BuyProduct(PurchaseRequestDto purchaseRequestDto);
        Task<BillDto> BuyProductsFromCart(PurchaseRequestDto purchaseRequestDto);
    }
}
