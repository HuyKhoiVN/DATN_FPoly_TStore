using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TSizeController : TBaseController<Size>
    {
        IBaseServices<Size> _services;
        public TSizeController(IBaseServices<Size> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
