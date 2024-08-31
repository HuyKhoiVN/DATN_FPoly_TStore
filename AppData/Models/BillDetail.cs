using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class BillDetail
	{
		public Guid Id { get; set; }
		public Guid IdProductDetail { get; set; }
		public Guid IdBill { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int Amount { get; set; }

		/// <summary>
		/// Giá sản phẩm TẠI THỜI ĐIỂM MUA HÀNG
		/// </summary>
		public Decimal Price { get; set; }

		/// <summary>
		/// Số tiền giảm
		/// </summary>
		public Decimal Discount { get; set; }
		public bool Status { get; set; }

        public ProductDetail? ProductDetail { get; set; }
        public Bill? Bill { get; set; }

    }
}
