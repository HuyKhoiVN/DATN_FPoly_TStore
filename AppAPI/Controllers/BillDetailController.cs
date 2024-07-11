using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    public class BillDetailController : Controller
    {
        ICRUDApi<BillDetail> _crud;
        TStoreDb _context = new TStoreDb();

        public BillDetailController()
        {
            CRUDApi<BillDetail> crud = new CRUDApi<BillDetail>(_context, _context.BillDetails);
            _crud = crud;
        }

        [HttpGet("get-all-billDetail")]
        public IEnumerable<BillDetail> GetBillDetails()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpGet("get-billDetail-byBillId")]
        public IEnumerable<BillDetail> GetBillDetailsByBillId(Guid idBill)
        {
            var billDetails = _context.BillDetails.Where(b => b.IdBill == idBill);
            return billDetails.ToList();
        }

        [HttpPost("create-new-billDetail")]
        public bool CreateBillDetail(Guid idProductDetail, Guid idBill, int amount, decimal price, decimal discount)
        {
            var billDetail = new BillDetail();

            billDetail.Id = new Guid();
            billDetail.IdProductDetail = idProductDetail;
            billDetail.IdBill = idBill;
            billDetail.Amount = amount;
            billDetail.Price = price;
            billDetail.Discount = discount;
            billDetail.Status = true;

            return _crud.CreateItem(billDetail);
        }

        [HttpPut("update-billDetail")]
        public bool UpdateBillDetail(Guid id, Guid idProductDetail, Guid idBill, int amount, 
            decimal price, decimal discount, bool status)
        {
            var billDetail = _context.BillDetails.FirstOrDefault(p => p.Id == id);
            if (billDetail != null)
            {
                billDetail.IdProductDetail = idProductDetail;
                billDetail.IdBill = idBill;
                billDetail.Amount = amount;
                billDetail.Price = price;
                billDetail.Discount = discount;
                billDetail.Status = status;
                return _crud.UpdateItem(billDetail);
            }
            return false;
        }

        /*[HttpDelete("delete-billDetail")]
        public bool DeleteBillDetail(Guid id)
        {
            var billDetail = _context.BillDetails.FirstOrDefault(b => b.Id == id);
            if(billDetail != null)
            {
                return _crud.DeleteItem(billDetail);
            }
            return false;
        }*/

        [HttpPut("soft-delete-billDetail")]
        public bool SoftDeleteBillDetail(Guid id)
        {
            var billDetail = _context.BillDetails.FirstOrDefault(x => x.Id == id);
            if (billDetail != null)
            {
                billDetail.Status = false;
                return _crud.UpdateItem(billDetail);
            }
            return false;
        }
    }
}
