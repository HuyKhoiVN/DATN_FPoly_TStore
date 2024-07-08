using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;


namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : Controller
    {
        ICRUDApi<Color> _crud;
        TStoreDb _context = new TStoreDb();

        public ColorsController()
        {
            CRUDApi<Color> crud = new CRUDApi<Color>(_context, _context.Colors);
            _crud = crud;
        }


        [HttpGet("get-all-colors")]
        public IEnumerable<Color> GetColors()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-color")]
        public bool CreateColor(string colorName)
        {
            Color color = new Color();
            color.Id = new Guid();
            color.ColorName = colorName;
            color.Status = true;
            return _crud.CreateItem(color);
        }

        [HttpPut("update-color")]
        public bool UpdateColor(Guid id, string colorName, bool status)
        {
            var color = _context.Colors.FirstOrDefault(p => p.Id == id);
            if (color != null)
            {
                color.ColorName = colorName;
                color.Status = status;
                return _crud.UpdateItem(color);
            }
            return false;
        }

        /*[HttpDelete("delete-color")]
        public bool DeleteColor(Guid id)
        {
            var color = _context.Colors.FirstOrDefault(p => p.Id == id);
            if (color != null)
            {
                return _crud.DeleteItem(color);
            }
            return false;
        }*/

        [HttpPut("soft-delete")]
        public bool SoftDeleteColor(Guid id)
        {
            var color = _context.Colors.FirstOrDefault(x => x.Id == id);
            if (color != null)
            {
                color.Status = false;
                return _crud.UpdateItem(color);
            }
            return false;
        }
    }
}
