using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : TBaseController<CartDetail>
    {
        IBaseServices<CartDetail> _services;
        public CartDetailController(IBaseServices<CartDetail> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
