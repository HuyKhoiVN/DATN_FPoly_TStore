using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public Guid IdSize { get; set; }
        public Size? Size { get; set; }
        public Guid IdColor { get; set; }
        public Color? Color { get; set; }
        public Guid IdProductCategory { get; set; }
        public ProductCatergory? ProductCatergory { get; set; }
        public Guid IdProducer { get; set; }
        public Producer? Producer { get; set; } 
        public Guid IdProduct { get; set; }
        public Product? Product { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Rating { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public bool Status { get; set; }

        public ICollection<CartDetail>? CartDetails { get; set; }
        public ICollection<BillDetail>? BillDetails { get; set; }
        public ICollection<Image>? Images { get; set; }

    }
}
