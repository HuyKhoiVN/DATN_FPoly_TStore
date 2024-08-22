using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductController : TBaseController<Product>
    {
        IBaseServices<Product> _services;
        public TProductController(IBaseServices<Product> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
