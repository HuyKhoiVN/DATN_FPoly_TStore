using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : TBaseController<ProductDetail>
    {
        IBaseServices<ProductDetail> _services;
        public ProductDetailController(IBaseServices<ProductDetail> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
