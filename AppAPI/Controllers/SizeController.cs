using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : TBaseController<Size>
    {
        IBaseServices<Size> _services;
        public SizeController(IBaseServices<Size> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
