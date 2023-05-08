using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EventRefund
    {
        public int RefundId { get; set; }
        public int? EventId { get; set; }
        public decimal Amount { get; set; }

        public virtual Event? Event { get; set; }
    }
}
