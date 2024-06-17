using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        public string? ColorName { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
} 
