using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProductDetailController : TBaseController<ProductDetail>
    {
        IBaseServices<ProductDetail> _services;
        public TProductDetailController(IBaseServices<ProductDetail> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
