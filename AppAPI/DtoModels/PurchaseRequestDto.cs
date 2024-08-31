namespace AppAPI.DtoModels
{
    public class PurchaseRequestDto
    {
        public Guid AccountId { get; set; }
        public Guid PaymentMethodId { get; set; }
        public decimal ShipFee { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public List<PurchaseItemDto>? Items { get; set; }
    }
}
