using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TAddressController : TBaseController<Address>
    {
        IBaseServices<Address> _services;
        public TAddressController(IBaseServices<Address> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
