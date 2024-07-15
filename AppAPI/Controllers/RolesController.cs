using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        ICRUDApi<Role> _crud;
        TStoreDb _context = new TStoreDb();

        public RolesController()
        {
            CRUDApi<Role> crud = new CRUDApi<Role>(_context, _context.Roles);
            _crud = crud;
        }

        [HttpGet("get-all-roles")]
        public IEnumerable<Role> GetAllRoles()
        {
            return _crud.GetAllItems().ToList();
        }

        [HttpPost("create-role")]
        public bool CreateRole(string name)
        {
            Role role = new Role();

            role.Id = Guid.NewGuid();
            role.Name = name;
            role.Status = true;

            return _crud.CreateItem(role);
        }

        [HttpPut("update-role")]
        public bool UpdateRole(Guid id, string name, bool status)
        {
            var role = _context.Roles.FirstOrDefault(p => p.Id == id);
            if (role != null)
            {
                role.Name = name;
                role.Status = status;
                return _crud.UpdateItem(role);
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
        public bool SoftDeleteRole(Guid id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                role.Status = false;
                return _crud.UpdateItem(role);
            }
            return false;
        }
    }
}
