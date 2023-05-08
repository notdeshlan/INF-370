using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomPaymentType
    {
        public RoomPaymentType()
        {
            RoomPayments = new HashSet<RoomPayment>();
        }

        public int PaymentTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;

        public virtual ICollection<RoomPayment> RoomPayments { get; set; }
    }
}
