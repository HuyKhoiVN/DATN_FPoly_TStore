using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TRoleController : TBaseController<Role>
    {
        IBaseServices<Role> _services;
        public TRoleController(IBaseServices<Role> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
