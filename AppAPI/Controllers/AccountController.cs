using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : TBaseController<Account>
    {
        IBaseServices<Account> _services;
        public AccountController(IBaseServices<Account> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
