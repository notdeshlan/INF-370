using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EventPaymentType
    {
        public EventPaymentType()
        {
            EventPayments = new HashSet<EventPayment>();
        }

        public int PaymentTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;

        public virtual ICollection<EventPayment> EventPayments { get; set; }
    }
}
