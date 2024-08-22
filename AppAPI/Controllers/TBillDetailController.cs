using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TBillDetailController : TBaseController<BillDetail>
    {
        IBaseServices<BillDetail> _services;

        public TBillDetailController(IBaseServices<BillDetail> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
