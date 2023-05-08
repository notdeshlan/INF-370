using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class SupplierOrder
    {
        public SupplierOrder()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int? SupplierId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
