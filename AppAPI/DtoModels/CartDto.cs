namespace AppAPI.DtoModels
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public Guid AccountId { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
