namespace AppAPI.DtoModels
{
    public class BillDetailDto
    {
        public Guid Id { get; set; }
        public Guid IdProductDetail { get; set; }
        public int Amount { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
    }
}
