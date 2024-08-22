using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : TBaseController<Color>
    {
        IBaseServices<Color> _services;
        public ColorController(IBaseServices<Color> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
