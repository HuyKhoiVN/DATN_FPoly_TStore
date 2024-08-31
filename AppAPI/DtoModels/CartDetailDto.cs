namespace AppAPI.DtoModels
{
    public class CartDetailDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public decimal TotalPrice => SalePrice * Quantity; // Tính tổng tiền cho sản phẩm
        public int Quantity { get; set; }
    }

}
