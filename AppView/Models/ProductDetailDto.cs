namespace AppView.Models
{
    public class ProductDetailDto
    {
        public string? Name { get; set; }
        public List<string>? Images { get; set; }
        public string? Rating { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ProductDetailInfoDto>? Details { get; set; }
    }
}
