using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatergoryController : TBaseController<ProductCatergory>
    {
        IBaseServices<ProductCatergory> _services;
        public ProductCatergoryController(IBaseServices<ProductCatergory> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
