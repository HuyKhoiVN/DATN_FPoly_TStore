using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	public class CartController : Controller
	{
		ICRUDApi<Cart> _crud;
		TStoreDb _context = new TStoreDb();
        public CartController()
        {
			CRUDApi<Cart> crud = new CRUDApi<Cart>(_context, _context.Carts);
			_crud = crud;
        }

		[HttpGet("get-all-cart")]
		public IEnumerable<Cart> GetCart() 
		{
			return _crud.GetAllItems().ToList();
		}

		[HttpGet("get-cartByID")]
		public IEnumerable<Cart> GetCartByID(Guid idCart)
		{
			var cart = _context.Carts.Where(c => c.Id == idCart);
			return cart.ToList();
		}

		[HttpPost("create-cart")]
		public bool CreateCart(Guid idAccount, DateTime createDate, DateTime updateDate, bool status)
		{
			var cart = new Cart();
			cart.Id = new Guid();
			cart.IdAccount = idAccount;
			cart.CreateDate = DateTime.Now;
			cart.UpdateDate = updateDate;
			cart.Status = status;
			return _crud.CreateItem(cart);
		}

		[HttpPut("update-cart")]
		public bool UpdateCart(Guid id, Guid idAccount, DateTime createDate, DateTime updateDate, bool status)
		{
			var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
			if (cart != null)
			{
				cart.IdAccount = idAccount;
				cart.CreateDate = createDate;
				cart.UpdateDate = updateDate;
				cart.Status = status;
				return _crud.UpdateItem(cart);
			}
			return false;
		}

		[HttpDelete("delete-cart")]
		public bool DeleteCart(Guid id)
		{
			var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
			if (cart != null) 
			{
				return _crud.DeleteItem(cart);
			}
			return false;
		}
	}
}
