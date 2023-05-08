using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RecieveSupplierOrder
    {
        public RecieveSupplierOrder()
        {
            RsoLines = new HashSet<RsoLine>();
        }

        public int RsoId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? RsoDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual ICollection<RsoLine> RsoLines { get; set; }
    }
}
