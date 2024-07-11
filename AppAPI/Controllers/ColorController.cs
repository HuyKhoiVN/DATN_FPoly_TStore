using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        ICRUDApi<Color> _crud;
        TStoreDb _context = new TStoreDb();

        public ColorController()
        {
            CRUDApi<Color> crud = new CRUDApi<Color>(_context, _context.Colors);
        }
        [HttpGet("get-all-color")]
        public IEnumerable<Color> GetColors()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("creat-color")]
        public bool CreateColor(string name)
        {
            Color color = new Color();
            color.Id = Guid.NewGuid();
            color.ColorName = name;
            color.Status = true;
            return _crud.CreateItem(color);
        }

        [HttpPut("update-color")]
        public bool UpdateColor(Guid id, string name, bool status)
        {
            var color = _context.Colors.FirstOrDefault(p => p.Id == id);
            if (color == null)
            {
                color.ColorName = name;
                color.Status = status;
                return _crud.UpdateItem(color);
            }
            return false;
        }
    }
}
