using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AuditLogs = new HashSet<AuditLog>();
            RecieveSupplierOrders = new HashSet<RecieveSupplierOrder>();
            RoomInspections = new HashSet<RoomInspection>();
            SupplierOrders = new HashSet<SupplierOrder>();
            VenueInspections = new HashSet<VenueInspection>();
        }

        public int EmployeeId { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int EmployeeUserId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateTime? HireDate { get; set; }

        public virtual EmployeeType? EmployeeType { get; set; }
        public virtual User EmployeeUser { get; set; } = null!;
        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual ICollection<RecieveSupplierOrder> RecieveSupplierOrders { get; set; }
        public virtual ICollection<RoomInspection> RoomInspections { get; set; }
        public virtual ICollection<SupplierOrder> SupplierOrders { get; set; }
        public virtual ICollection<VenueInspection> VenueInspections { get; set; }
    }
}
