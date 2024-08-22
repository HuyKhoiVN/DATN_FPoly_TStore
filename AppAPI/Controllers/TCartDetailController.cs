using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCartDetailController : TBaseController<CartDetail>
    {
        IBaseServices<CartDetail> _services;
        public TCartDetailController(IBaseServices<CartDetail> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
