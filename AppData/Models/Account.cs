using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? TokenResetPassword { get; set; }
        public bool ResetTokenExperises { get; set; }

        public Guid IdRole { get; set; }
        public Role? Role { get; set; }

        public DateTime Dob { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }

        public DateTime? CreatedDate { get; set;}
        public DateTime? ModifiedDate { get;set;}

        public bool Status { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
