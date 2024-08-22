using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : TBaseController<News>
    {
        IBaseServices<News> _services;
        public NewsController(IBaseServices<News> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
