using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EventPayment
    {
        public int EventPaymentId { get; set; }
        public int? ClientId { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public byte[] ProofOfPayment { get; set; } = null!;

        public virtual Client? Client { get; set; }
        public virtual EventPaymentType? PaymentType { get; set; }
    }
}
