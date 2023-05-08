using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomBooking
    {
        public RoomBooking()
        {
            Reviews = new HashSet<Review>();
            RoomBookingRefunds = new HashSet<RoomBookingRefund>();
            RoomDateTimes = new HashSet<RoomDateTime>();
            RoomPayments = new HashSet<RoomPayment>();
        }

        public int RoomBookingId { get; set; }
        public int? RoomBookingStatusId { get; set; }
        public string ReferenceNumber { get; set; } = null!;
        public DateTime? BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfRooms { get; set; }

        public virtual RoomBookingStatus? RoomBookingStatus { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<RoomBookingRefund> RoomBookingRefunds { get; set; }
        public virtual ICollection<RoomDateTime> RoomDateTimes { get; set; }
        public virtual ICollection<RoomPayment> RoomPayments { get; set; }
    }
}
