using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TColorController : TBaseController<Color>
    {
        IBaseServices<Color> _services;
        public TColorController(IBaseServices<Color> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
