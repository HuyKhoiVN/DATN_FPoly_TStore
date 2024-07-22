using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        ICRUDApi<Address> _crud;
        TStoreDb _context = new TStoreDb();

        public AddressController()
        {
            CRUDApi<Address> crud = new CRUDApi<Address>(_context, _context.Addresses);
            _crud = crud;
        }

        [HttpGet("get-all-Address")]
        public IEnumerable<Address> GetAccdress()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-Address")]
        public bool CreateAddress(Guid Idacccount,string City, string District,string ward,string DefaultAddress,bool status)
        {
            Address ad = new Address();

            ad.Id = Guid.NewGuid();
            ad.City = City;
            ad.District = District;
            ad.Ward = ward;
            ad.DefaultAddress = DefaultAddress;
            ad.Status = true;
            ad.IdAccount = Idacccount;

            return _crud.CreateItem(ad);
        }

        [HttpPut("update-address")]
        public bool UpdateAddress(Guid id, Guid Idacccount, string City, string District, string ward, string DefaultAddress, bool status)
        {
            var ad = _context.Addresses.FirstOrDefault(p => p.Id == id);
            if (ad != null)
            {
                ad.City = City;
                ad.District = District;
                ad.Ward = ward;
                ad.DefaultAddress = DefaultAddress;
                ad.Status = status;
                ad.IdAccount = Idacccount;
                return _crud.UpdateItem(ad);
            }
            return false;
        }

        /*[HttpDelete("delete-size")]
        public bool Deletesize(Guid id)
        {
            var size = _context.Sizes.FirstOrDefault(p => p.Id == id);
            if (size != null)
            {
                return _crud.DeleteItem(size);
            }
            return false;
        }*/

        [HttpPut("soft-delete")]
        public bool SoftDeleteAddress(Guid id)
        {
            var ad = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (ad != null)
            {
                ad.Status = false;
                return _crud.UpdateItem(ad);
            }
            return false;
        }
    }
}
