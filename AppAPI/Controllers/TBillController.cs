using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBillController : TBaseController<Bill>
    {
        IBaseServices<Bill> _services;
        public TBillController(IBaseServices<Bill> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
