using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : TBaseController<Bill>
    {
        IBaseServices<Bill> _services;
        public BillController(IBaseServices<Bill> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
