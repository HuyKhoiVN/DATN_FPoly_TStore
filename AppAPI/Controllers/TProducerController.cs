using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TProducerController : TBaseController<Producer>
    {
        IBaseServices<Producer> _services;
        public TProducerController(IBaseServices<Producer> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
