using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TPaymentMethodController : TBaseController<PaymentMethod>
    {
        IBaseServices<PaymentMethod> _services;

        public TPaymentMethodController(IBaseServices<PaymentMethod> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
