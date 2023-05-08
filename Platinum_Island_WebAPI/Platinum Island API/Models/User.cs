using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class User
    {
        public User()
        {
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }

        public int UserId { get; set; }
        public int? UserRoleId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Role? UserRole { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
