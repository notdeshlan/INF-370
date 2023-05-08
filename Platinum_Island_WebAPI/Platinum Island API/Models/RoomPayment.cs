using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomPayment
    {
        public int RoomPaymentId { get; set; }
        public int? ClientId { get; set; }
        public int? RoomBookingId { get; set; }
        public int? PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public byte[] ProofOfPayment { get; set; } = null!;

        public virtual Client? Client { get; set; }
        public virtual RoomPaymentType? PaymentType { get; set; }
        public virtual RoomBooking? RoomBooking { get; set; }
    }
}
