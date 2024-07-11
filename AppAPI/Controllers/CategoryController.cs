using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICRUDApi<Category> _crud;
        TStoreDb _context = new TStoreDb();

        public CategoryController()
        {
            CRUDApi<Category> crud = new CRUDApi<Category>(_context, _context.Categories);
            _crud = crud;
        }

        [HttpGet("get-all-Categories")]
        public IEnumerable<Category> GetCategories()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-Category")]
        public bool CreateCategory(string name, string description)
        {
            Category category = new Category();

            category.Id = Guid.NewGuid();
            category.Name = name;
            category.Description = description;
            category.CreatedDate = DateTime.Now;
            category.ModifiledDate = DateTime.Now;
            category.Status = true;

            return _crud.CreateItem(category);
        }

        [HttpPut("update-Category")]
        public bool UpdateCategory(Guid id, string name, string description, bool status)
        {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                category.Name = name;
                category.Description = description;
                category.ModifiledDate = DateTime.Now;
                category.Status = status;
                return _crud.UpdateItem(category);
            }
            return false;
        }

        /*[HttpDelete("delete-category")]
        public bool DeleteCategory(Guid id)
        {
            var category = _context.Categorys.FirstOrDefault(p => p.Id == id);
            if (category != null)
            {
                return _crud.DeleteItem(category);
            }
            return false;
        }*/

        [HttpPut("soft-delete-category")]
        public bool SoftDeleteCategory(Guid id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                category.Status = false;
                return _crud.UpdateItem(category);
            }
            return false;
        }
    }
}
