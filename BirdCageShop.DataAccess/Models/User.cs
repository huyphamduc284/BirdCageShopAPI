using System;
using System.Collections.Generic;

namespace BirdCageShop.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            Vouchers = new HashSet<Voucher>();
        }

        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public int? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
