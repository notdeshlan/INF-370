using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomDateTime
    {
        public int DateId { get; set; }
        public int TimeId { get; set; }
        public int? RoomBookingId { get; set; }
        public int? RoomId { get; set; }
        public int? RoomStatusId { get; set; }

        public virtual RoomDate Date { get; set; } = null!;
        public virtual Room? Room { get; set; }
        public virtual RoomBooking? RoomBooking { get; set; }
        public virtual RoomStatus? RoomStatus { get; set; }
        public virtual RoomTime Time { get; set; } = null!;
    }
}
