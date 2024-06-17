using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public Guid IdPorductDetail { get; set; }
        public ProductDetail? ProductDetail { get; set; }
    }
}
