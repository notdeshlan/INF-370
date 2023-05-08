using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierOrders = new HashSet<SupplierOrder>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public string SupplierPhone { get; set; } = null!;
        public string SupplierEmail { get; set; } = null!;

        public virtual ICollection<SupplierOrder> SupplierOrders { get; set; }
    }
}
