using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatergoryController : Controller
    {
        ICRUDApi<ProductCatergory> _crud;
        TStoreDb _context = new TStoreDb();
/*t*/
        public ProductCatergoryController()
        {
            CRUDApi<ProductCatergory> crud = new CRUDApi<ProductCatergory>(_context, _context.ProductCatergories);
            _crud = crud;
        }

        [HttpGet("get-all-ProductCatagori")]
        public IEnumerable<ProductCatergory> GetProCatagori()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-ProductCatagori")]
        public bool CreateProCatagori( string name, string description, DateTime createdate, string CreatedBy, bool status, DateTime ModifiledDate)
        {
            ProductCatergory Proca = new ProductCatergory();

            Proca.Id = Guid.NewGuid();
            Proca.Name = name;
            Proca.Description = description;
            Proca.CreatedDate = createdate;
            Proca.CreatedBy = CreatedBy;
            Proca.Status = true;
            Proca.ModifiledDate = ModifiledDate;
            
            return _crud.CreateItem(Proca);
        }

        [HttpPut("update-ProductCatagori")]
        public bool UpdateProductCatagori(Guid id, string name, string description, DateTime createdate, string CreatedBy, bool status, DateTime ModifiledDate)
        {
            var Proca = _context.ProductCatergories.FirstOrDefault(p => p.Id == id);
            if (Proca != null)
            {
                Proca.Name = name;
                Proca.Description = description;
                Proca.CreatedDate = createdate;
                Proca.CreatedBy = CreatedBy;
                Proca.Status = true;
                Proca.ModifiledDate = ModifiledDate;
                return _crud.UpdateItem(Proca);
            }
            return false;
        }

        /*[HttpDelete("delete-size")]
        public bool Deletesize(Guid id)
        {
            var size = _context.Sizes.FirstOrDefault(p => p.Id == id);
            if (size != null)
            {
                return _crud.DeleteItem(size);
            }
            return false;
        }*/

        [HttpPut("soft-delete")]
        public bool SoftDeleteProductcatagori(Guid id)
        {
            var proca = _context.ProductCatergories.FirstOrDefault(x => x.Id == id);
            if (proca != null)
            {
                proca.Status = false;
                return _crud.UpdateItem(proca);
            }
            return false;
        }

    }
}
