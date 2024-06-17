using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
               
        public Guid IdAccount { get; set; }
        public Account? Account { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public bool Status { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
