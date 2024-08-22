using AppAPI.Service;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : TBaseController<Image>
    {
        IBaseServices<Image> _services;

        public ImageController(IBaseServices<Image> baseServices) : base(baseServices)
        {
            _services = baseServices;
        }
    }
}
