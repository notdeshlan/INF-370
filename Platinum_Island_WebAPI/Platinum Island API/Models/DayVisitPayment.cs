using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitPayment
    {
        public int DayVisitPaymentId { get; set; }
        public int? ClientId { get; set; }
        public int? DayVisitId { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal Amount { get; set; }

        public virtual Client? Client { get; set; }
        public virtual DayVisit? DayVisit { get; set; }
        public virtual DayVisitPaymentType? PaymentType { get; set; }
    }
}
