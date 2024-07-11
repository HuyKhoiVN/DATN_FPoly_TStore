using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        ICRUDApi<Size> _crud;
        TStoreDb _context = new TStoreDb();

        public SizeController()
        {
            CRUDApi<Size> crud = new CRUDApi<Size>(_context, _context.Sizes);
            _crud = crud;
        }

        [HttpGet("get-all-sizes")]
        public IEnumerable<Size> GetSizes()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-size")]
        public bool CreateSize(string name)
        {
            Size size = new Size();

            size.Id = Guid.NewGuid();
            size.SizeName = name;
            size.Status = true;

            return _crud.CreateItem(size);
        }

        [HttpPut("update-size")]
        public bool Updatesize(Guid id, string name, bool status)
        {
            var size = _context.Sizes.FirstOrDefault(p => p.Id == id);
            if (size != null)
            {
                size.SizeName = name;
                size.Status = status;
                return _crud.UpdateItem(size);
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
        public bool SoftDeletesize(Guid id)
        {
            var size = _context.Sizes.FirstOrDefault(x => x.Id == id);
            if (size != null)
            {
                size.Status = false;
                return _crud.UpdateItem(size);
            }
            return false;
        }
    }
}
