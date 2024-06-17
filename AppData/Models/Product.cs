using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public bool Status { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set;}

    }
}
