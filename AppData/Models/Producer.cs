using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Producer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
