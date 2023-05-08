using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomBookingRefund
    {
        public int RefundId { get; set; }
        public int? RoomBookingId { get; set; }
        public decimal Amount { get; set; }

        public virtual RoomBooking? RoomBooking { get; set; }
    }
}
