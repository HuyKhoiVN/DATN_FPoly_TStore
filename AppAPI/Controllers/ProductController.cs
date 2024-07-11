using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        ICRUDApi<Product> _crud;
        TStoreDb _context = new TStoreDb();

        public ProductController()
        {
            CRUDApi<Product> crud = new CRUDApi<Product>(_context, _context.Products);
            _crud = crud;
        }

        [HttpGet("get-all-products")]
        public IEnumerable<Product> GetProducts()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-product")]
        public bool CreateProduct(string name, string code)
        {
            Product product = new Product();

            product.Id = Guid.NewGuid();
            product.Name = name;
            product.Code = code;
            product.CreatedDate = DateTime.Now;
            product.ModifiledDate = DateTime.Now;
            product.Status = true;

            return _crud.CreateItem(product);
        }

        [HttpPut("update-product")]
        public bool UpdateProduct(Guid id, string name, string code, bool status)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = name;
                product.Code = code;
                product.ModifiledDate = DateTime.Now;
                product.Status = status;
                return _crud.UpdateItem(product);
            }
            return false;
        }

        /*[HttpDelete("delete-product")]
        public bool DeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return _crud.DeleteItem(product);
            }
            return false;
        }*/

        [HttpPut("soft-delete-product")]
        public bool SoftDeleteProduct(Guid id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Status = false;
                return _crud.UpdateItem(product);
            }
            return false;
        }
    }
}
