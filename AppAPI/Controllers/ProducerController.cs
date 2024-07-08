using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        CRUDApi<Producer> _crud;
        TStoreDb _context = new TStoreDb();

        public ProducerController()
        {
            CRUDApi<Producer> crud = new CRUDApi<Producer>(_context, _context.Producers);
            _crud = crud;
        }

        [HttpGet]
        public IEnumerable<Producer> GetImages()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost]
        public bool Create(string name, string address)
        {
            Producer pro = new Producer();
            pro.Id = Guid.NewGuid();
            pro.Name = name;
            pro.Address = address;
            pro.Status = true;
            return _crud.CreateItem(pro);
        }


        [HttpPut]
        public bool Update(Guid id, string name, string address, bool status)
        {
            var pro = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (pro != null)
            {
                pro.Name = name;
                pro.Address = address;
                pro.Status = status;
                return _crud.UpdateItem(pro);
            }
            return false;
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            var pro = _context.Producers.FirstOrDefault(y => y.Id == id);
            if (pro != null)
            {
                return _crud.DeleteItem(pro);
            }
            return false;
        }

    }
}
