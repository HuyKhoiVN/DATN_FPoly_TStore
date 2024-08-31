namespace AppAPI.DtoModels
{
    public class CartRequestDto
    {
        public Guid AccountId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}