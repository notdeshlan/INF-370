using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class OrderLine
    {
        public OrderLine()
        {
            RsoLines = new HashSet<RsoLine>();
        }

        public int OrderLineId { get; set; }
        public int? ItemId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderTotal { get; set; }

        public virtual Item? Item { get; set; }
        public virtual SupplierOrder? Order { get; set; }
        public virtual ICollection<RsoLine> RsoLines { get; set; }
    }
}
