using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? ClientId { get; set; }
        public int? DayVisitId { get; set; }
        public int? EventId { get; set; }
        public int? RoomBookingId { get; set; }
        public byte Rating { get; set; }
        public string ReviewDescription { get; set; } = null!;

        public virtual Client? Client { get; set; }
        public virtual DayVisit? DayVisit { get; set; }
        public virtual Event? Event { get; set; }
        public virtual RoomBooking? RoomBooking { get; set; }
    }
}
