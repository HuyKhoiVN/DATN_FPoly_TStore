using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class Product
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Mã sản phẩm: SP-01, SP-02 ...
        /// </summary>
        public string Code { get; set; }
        public Decimal Price { get; set; }
        public string? Rating { get; set; }
        public string? Description { get; set; }

        public Guid IdProducer { get; set; }
        public Guid IdProductCategory { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public bool Status { get; set; }

        public Producer? Producer { get; set; }
        public ProductCatergory? ProductCatergory { get; set; }


        public ICollection<ProductDetail>? ProductDetails { get; set;}
        public ICollection<Image>? Images { get; set; }

    }
}
