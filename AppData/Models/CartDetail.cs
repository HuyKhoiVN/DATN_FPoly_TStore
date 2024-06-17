using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class CartDetail
	{
        public Guid Id { get; set; }

        public Guid IdProductDetail { get; set; }
		public ProductDetail? ProductDetail { get; set; }

		public Guid IdCart { get; set; }
		public Cart? Cart { get; set; }

		public Decimal OriginalPrice { get; set; }
		public Decimal SalePrice { get; set; }
		public int ProductQuantity { get; set; }

        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }

    }
}
