using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : TBaseController<Cart>
    {
        IBaseServices<Cart> _services;
        public CartController(IBaseServices<Cart> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
