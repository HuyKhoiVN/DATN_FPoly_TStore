using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class PaymentMethod
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string CreateBy { get; set; }
		public string UpdateBy { get; set; }
		public Decimal TotalMoney { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
		public ICollection<Bill> Bills { get; set; }
	}
}
