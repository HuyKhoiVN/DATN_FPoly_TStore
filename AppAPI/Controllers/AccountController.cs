using AppAPI.Service;
using AppData.Context;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ICRUDApi<Account> _crud;
        TStoreDb _context = new TStoreDb();

        public AccountController()
        {
            CRUDApi<Account> crud = new CRUDApi<Account>(_context, _context.Accounts);
            _crud = crud;
        }

        [HttpGet("get-all-Account")]
        public IEnumerable<Account> GetAccounts()
        {
            return _crud.GetAllItems().ToList();
        }


        [Route("Register")]
        [HttpPost]

        public bool CreateAccount( string name, string password, Guid Idrole, DateTime Dob, string email, bool gender, DateTime CreatedDate, bool status)
        {

            Account account = new Account();

            account.Id = Guid.NewGuid();
            account.CreatedDate = DateTime.Now;
            account.Status = status;
            var CheckRole = _context.Roles.Count();

            if (CheckRole == 0)
            {
                var customerRole = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Customer",
                    Status = true
                };
                _context.Roles.Add(customerRole);

                var adminRole = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Status = true
                };
                _context.Roles.Add(adminRole);

                var staffRole = new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Staff",
                    Status = true
                };
                _context.Roles.Add(staffRole);
                _context.SaveChangesAsync();
            }
            if (account.IdRole == null)
            {
                account.IdRole = _context.Roles.SingleOrDefault(c => c.Name == "Customer").Id;
                account.Status = false;
            }
            return _crud.CreateItem(account);
        }

        [Route("Delete")]
        [HttpPost]
        public bool DeleteAccount(Guid id)
        {
            Account item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Status = false;
            }
            return _crud.DeleteItem(item);

        }

        [Route("Update")]
        [HttpPut]

        public bool UpdateAccount(Guid id, string name, string password, Guid Idrole, DateTime Dob, string email, bool gender, DateTime CreatedDate, bool status)
        {

            Account item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);

            if (item != null)
            {

                
                item.Email = email;
                item.Gender = gender;
                item.CreatedDate = CreatedDate;
                item.Status = status;
                item.IdRole = Idrole;
                item.Username = name;
                item.Password = password;
                item.CreatedDate = CreatedDate;
                item.Dob = Dob;


            }
            return _crud.UpdateItem(item);
        }


        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public Guid RoleId { get; set; }
        }


        [Route("Login")]
        [HttpPost]

        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var account = _crud.GetAllItems().FirstOrDefault(a => a.Username == loginRequest.Username && a.Password == loginRequest.Password && a.IdRole == loginRequest.RoleId);
            if (account != null)
            {
                return Ok(new { message = "Login successful" });
            }
            return Unauthorized(new { message = "Invalid username, password, or role" });
        }

        [Route("Logout")]
        [HttpPost]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logout successful" });
        }
    }
}

