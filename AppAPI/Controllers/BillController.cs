using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : Controller
    {
        ICRUDApi<Bill> _crud;
        TStoreDb _context = new TStoreDb();

        public BillController()
        {
            CRUDApi<Bill> crud = new CRUDApi<Bill>(_context, _context.Bills);
            _crud = crud;
        }

        [HttpGet("get-all-bills")]
        public IEnumerable<Bill> GetBills()
        {
            return _crud.GetAllItems().ToList();
        }

        public bool CreateNewBill(int code, Guid idAccount, Guid idPaymentMethod, decimal shipFee, 
            string phoneNumber, string address, decimal totalMoney, decimal moneyReduce, 
             DateTime shipmentDate, DateTime paymentDate, 
            bool paymentStatus, string createBy, string updateBy)
        {
            Bill bill = new Bill();
            bill.Id = Guid.NewGuid();
            bill.Code = code;
            bill.IdAccount = idAccount;
            bill.IdPaymentMethod = idPaymentMethod;
            bill.ShipFee = shipFee;
            bill.PhoneNumber = phoneNumber;
            bill.Address = address;
            bill.TotalMoney = totalMoney;
            bill.MoneyReduce = moneyReduce;
            bill.CretaedDate = DateTime.Now;
            bill.ShipmentDate = shipmentDate;
            bill.PaymentDate = paymentDate;
            bill.PaymentStatus = paymentStatus;
            bill.CreateBy = createBy;
            bill.UpdateBy = updateBy;
            bill.Status = true;
            bill.Account = _context.Accounts.FirstOrDefault(a => a.Id == idAccount);
            bill.PaymentMethod = _context.PaymentMethods.FirstOrDefault(p => p.Id == idPaymentMethod);

            return _crud.CreateItem(bill);
        }
    
        public bool UpdateBill(Guid id, int code, Guid idAccount, Guid idPaymentMethod, decimal shipFee,
            string phoneNumber, string address, decimal totalMoney, decimal moneyReduce, DateTime shipmentDate, 
            DateTime paymentDate, bool paymentStatus, string createdBy, string updateBy, bool status)
        {
            var bill = _context.Bills.FirstOrDefault(b => b.Id == id);
            if (bill != null)
            {
                bill.Code = code;
                bill.IdAccount = idAccount;
                bill.IdPaymentMethod = idPaymentMethod;
                bill.ShipFee = shipFee;
                bill.PhoneNumber = phoneNumber;
                bill.Address = address;
                bill.TotalMoney = totalMoney;
                bill.MoneyReduce = moneyReduce;
                bill.ShipmentDate = shipmentDate;
                bill.PaymentDate = paymentDate;
                bill.PaymentStatus = paymentStatus;
                bill.CreateBy = createdBy;
                bill.UpdateBy = updateBy;  
                bill.Status = status;
                bill.Account = _context.Accounts.FirstOrDefault(a => a.Id == idAccount);
                bill.PaymentMethod = _context.PaymentMethods.FirstOrDefault(a => a.Id == idPaymentMethod);

                return _crud.UpdateItem(bill);
            }
            return false;
        }
    
        public bool DeleteBill(Guid id)
        {
            var bill = _context.Bills.FirstOrDefault(b => b.Id == id);
            if(bill != null)
            {
                return _crud.DeleteItem(bill);
            }
            return false;
        }
    }
}
