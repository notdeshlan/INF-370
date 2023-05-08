using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitPaymentType
    {
        public DayVisitPaymentType()
        {
            DayVisitPayments = new HashSet<DayVisitPayment>();
        }

        public int PaymentTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;

        public virtual ICollection<DayVisitPayment> DayVisitPayments { get; set; }
    }
}
