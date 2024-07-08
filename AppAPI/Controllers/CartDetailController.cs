using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	public class CartDetailController : Controller
	{
		ICRUDApi<CartDetail> _crud;
		TStoreDb _context = new TStoreDb();
		public CartDetailController()
		{
			CRUDApi<CartDetail> crud = new CRUDApi<CartDetail>(_context, _context.CartDetails);
			_crud = crud;
		}

		[HttpGet("get-all-cartDetail")]
		public IEnumerable<CartDetail> GetCartDetail()
		{
			return _crud.GetAllItems().ToList();
		}

		[HttpGet("get-cartDetailByID")]
		public IEnumerable<CartDetail> GetCartDetailByID(Guid idCartDetail)
		{
			var cartDetail = _context.CartDetails.Where(c => c.Id == idCartDetail);
			return cartDetail.ToList();
		}

		[HttpPost("create-cartDetail")]
		public bool CreateCartDetail(Guid idProductDetail, Guid idCart, Decimal originalPrice, Decimal salePrice, int productQuantity, DateTime createDate, DateTime updateDate)
		{
			var cartDetail = new CartDetail();
			cartDetail.Id = new Guid();
			cartDetail.IdProductDetail = idProductDetail;
			cartDetail.IdCart = idCart;
			cartDetail.OriginalPrice = originalPrice;
			cartDetail.SalePrice = salePrice;
			cartDetail.ProductQuantity = productQuantity;
			cartDetail.Create_date = DateTime.Now;
			cartDetail.Update_date = updateDate;
			return _crud.CreateItem(cartDetail);
		}

		[HttpPut("update-cartDetail")]
		public bool UpdateCartDetail(Guid id, Guid idProductDetail, Guid idCart, Decimal originalPrice, Decimal salePrice, int productQuantity, DateTime createDate, DateTime updateDate)
		{
			var cartDetail = _context.CartDetails.FirstOrDefault(c => c.Id == id);
			if (cartDetail != null)
			{
				cartDetail.IdProductDetail = idProductDetail;
				cartDetail.IdCart = idCart;
				cartDetail.OriginalPrice = originalPrice;
				cartDetail.SalePrice = salePrice;
				cartDetail.ProductQuantity = productQuantity;
				cartDetail.Create_date = createDate;
				cartDetail.Update_date = updateDate;
				return _crud.UpdateItem(cartDetail);
			}
			return false;
		}

		[HttpDelete("delete-cartDetail")]
		public bool DeleteCartDetail(Guid id)
		{
			var cartDetail = _context.CartDetails.FirstOrDefault(c => c.Id == id);
			if (cartDetail != null)
			{
				return _crud.DeleteItem(cartDetail);
			}
			return false;
		}
	}
}
