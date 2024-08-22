using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : TBaseController<Category>
    {
        IBaseServices<Category> _services;

        public CategoryController(IBaseServices<Category> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
