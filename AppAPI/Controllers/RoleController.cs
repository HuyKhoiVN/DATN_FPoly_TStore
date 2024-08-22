using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : TBaseController<Role>
    {
        IBaseServices<Role> _services;
        public RoleController(IBaseServices<Role> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
