using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class Account
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? TokenResetPassword { get; set; }
        public bool ResetTokenExperises { get; set; }

        public Guid IdRole { get; set; }

        public string? AvatarUrl {  get; set; }

        public DateTime Dob { get; set; }
        public string? Email { get; set; }
        public bool Gender { get; set; }

        public DateTime? CreatedDate { get; set;}
        public DateTime? ModifiedDate { get;set;}

        public bool Status { get; set; }
        public Role? Role { get; set; }

        public ICollection<Address>? Address { get; set; }
        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }

    }
}
