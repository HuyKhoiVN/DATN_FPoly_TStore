using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : TBaseController<PaymentMethod>
    {
        IBaseServices<PaymentMethod> _services;

        public PaymentMethodController(IBaseServices<PaymentMethod> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
