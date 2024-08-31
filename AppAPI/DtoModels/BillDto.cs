using AppData.Enum;

namespace AppAPI.DtoModels
{
    public class BillDto
    {
        /// <summary>
        /// Id của Bill gốc
        /// </summary>
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid IdAccount { get; set; }
        public Guid IdPaymentMethod { get; set; }
        public Decimal ShipFee { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public EnumBillStatus BillStatus { get; set; }
        public Decimal TotalMoney { get; set; } // Tính toán dựa trên BillDetails
        public Decimal MoneyReduce { get; set; } // Tính toán dựa trên Voucher hoặc khuyến mãi
        public ICollection<BillDetailDto>? BillDetails { get; set; }
    }
}
