using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        CRUDApi<Image> _crud;
        TStoreDb _context = new TStoreDb();

        public ImageController()    
        {
            CRUDApi<Image> crud = new CRUDApi<Image>(_context, _context.Images);
            _crud = crud;
        }

        [HttpGet("get-all-image")]
        public IEnumerable<Image> GetImages()
        {
            return _crud.GetAllItems().ToList();
        }

        
        [HttpPost("create-new-image")]
        public bool CreateImage(string imageUrl, Guid idproductdetail)
        {
            Image image = new Image();
            image.Id = Guid.NewGuid();
            image.ImageUrl = imageUrl;
            image.Status = true;
            image.IdPorductDetail = idproductdetail;
            return _crud.CreateItem(image);
        }
 
        [HttpPut("edit-image")]
        public bool UpdateImage(Guid id, string imageUrl, bool status, Guid idproductdetail)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == id);
            if (image != null)
            {
                image.ImageUrl = imageUrl;
                image.Status = status;
                image.IdPorductDetail = idproductdetail;
                return _crud.UpdateItem(image);
            }
            return false;
        }

        [HttpDelete("delete-image")]
        public bool DeleteImage(Guid id)
        {
            var image = _context.Images.FirstOrDefault(y => y.Id == id);
            if (image != null)
            {
                return _crud.DeleteItem(image);
            }
            return false;
        }
    }
}
