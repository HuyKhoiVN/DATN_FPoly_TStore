using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductCatergoryController : TBaseController<ProductCatergory>
    {
        IBaseServices<ProductCatergory> _services;
        public TProductCatergoryController(IBaseServices<ProductCatergory> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
