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
    public class Color
    {
        public Guid Id { get; set; }
        public string? ColorName { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductDetail>? ProductDetails { get; set; }
    }
} 
