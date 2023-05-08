using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitRefund
    {
        public int RefundId { get; set; }
        public int? DayVisitId { get; set; }
        public decimal Amount { get; set; }

        public virtual DayVisit? DayVisit { get; set; }
    }
}
