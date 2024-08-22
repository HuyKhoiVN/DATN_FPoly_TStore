using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : TBaseController<Product>
    {
        IBaseServices<Product> _services;
        public ProductController(IBaseServices<Product> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
