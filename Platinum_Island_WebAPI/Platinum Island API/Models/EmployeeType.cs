using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
