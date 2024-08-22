using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : TBaseController<Voucher>
    {
        IBaseServices<Voucher> _services;
        public VoucherController(IBaseServices<Voucher> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
