using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomBookingStatus
    {
        public RoomBookingStatus()
        {
            RoomBookings = new HashSet<RoomBooking>();
        }

        public int RoomBookingStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}
