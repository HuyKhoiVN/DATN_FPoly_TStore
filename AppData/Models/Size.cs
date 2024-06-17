using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public string? SizeName { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
