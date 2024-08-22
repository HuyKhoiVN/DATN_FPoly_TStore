using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCartController : TBaseController<Cart>
    {
        IBaseServices<Cart> _services;
        public TCartController(IBaseServices<Cart> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
