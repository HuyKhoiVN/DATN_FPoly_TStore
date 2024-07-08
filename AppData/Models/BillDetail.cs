using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class BillDetail
	{
		public Guid Id { get; set; }
		public Guid IdProductDetail { get; set; }
		public ProductDetail? ProductDetail { get; set; }
		public Guid IdBill { get; set; }            
        public Bill? Bill { get; set; }
		public int Amount { get; set; }
		public Decimal Price { get; set; }
		public Decimal Discount { get; set; }
		public bool Status { get; set; }

    }
}
