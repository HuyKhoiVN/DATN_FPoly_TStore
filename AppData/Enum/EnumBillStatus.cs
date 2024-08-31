using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Enum
{
    public enum EnumBillStatus
    {
        Pending,   // Chờ thanh toán
        Paid,      // Đã thanh toán
        Shipping,  // Đang giao
        Shipped,   // Đã giao hàng
        Cancelled  // Đã hủy
    }
}
