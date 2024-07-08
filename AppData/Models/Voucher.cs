using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Voucher
	{
		public Guid Id { get; set; }
		public Guid IdBill { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public double Value { get; set; }
		public int Quantity { get; set; }
		public double DiscountAmount { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool Status { get; set; }
		public Bill? Bill { get; set; }
	}
}
