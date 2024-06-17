using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class News
    {
        public Guid Id { get; set; } 
        public Guid IdCategory { get; set; }
        public Category? Category { get; set; }
        public string? Tittle { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiledDate { get; set;}
        public bool Status { get; set; }
    }
}
