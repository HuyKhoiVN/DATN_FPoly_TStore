using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : TBaseController<Producer>
    {
        IBaseServices<Producer> _services;
        public ProducerController(IBaseServices<Producer> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
