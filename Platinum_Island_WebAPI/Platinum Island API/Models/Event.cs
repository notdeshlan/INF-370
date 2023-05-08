using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Event
    {
        public Event()
        {
            EventRefunds = new HashSet<EventRefund>();
            EventTickets = new HashSet<EventTicket>();
            Reviews = new HashSet<Review>();
            VenueDateTimes = new HashSet<VenueDateTime>();
        }

        public int EventId { get; set; }
        public int? EventStatusId { get; set; }
        public int? ClientId { get; set; }
        public string EventDescription { get; set; } = null!;
        public int NumGuests { get; set; }
        public decimal Total { get; set; }

        public virtual Client? Client { get; set; }
        public virtual EventStatus? EventStatus { get; set; }
        public virtual ICollection<EventRefund> EventRefunds { get; set; }
        public virtual ICollection<EventTicket> EventTickets { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<VenueDateTime> VenueDateTimes { get; set; }
    }
}
