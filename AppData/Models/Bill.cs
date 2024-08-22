using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class Bill
	{
		public Guid Id { get; set; }
		public int Code { get; set; }
		public Guid IdAccount { get; set; }
		public Guid IdPaymentMethod { get; set; }
		public Decimal ShipFee { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public Decimal TotalMoney { get; set; }
		public Decimal MoneyReduce { get; set; }
		public DateTime CretaedDate { get; set; }
		public DateTime ShipmentDate { get; set; }
		public DateTime PaymentDate { get; set; }
		public bool PaymentStatus { get; set; }
		public string CreateBy { get; set; }
		public string UpdateBy { get; set; }
		public bool Status { get; set; }
		public Account? Account { get; set; }
		public PaymentMethod? PaymentMethod { get; set; }
		public ICollection<BillDetail>? BillDetails { get; set; }
		public ICollection<Voucher>? Vouchers { get; set; }

	}
}
