using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Client
    {
        public Client()
        {
            DayVisitPayments = new HashSet<DayVisitPayment>();
            DayVisits = new HashSet<DayVisit>();
            EventPayments = new HashSet<EventPayment>();
            Events = new HashSet<Event>();
            Reviews = new HashSet<Review>();
            RoomPayments = new HashSet<RoomPayment>();
        }

        public int ClientId { get; set; }
        public int? ClientUserId { get; set; }
        public string ClientName { get; set; } = null!;
        public string ClientSurname { get; set; } = null!;
        public string ClientEmail { get; set; } = null!;
        public string ClientPhone { get; set; } = null!;
        public string ClientIdnum { get; set; } = null!;

        public virtual User? ClientUser { get; set; }
        public virtual ICollection<DayVisitPayment> DayVisitPayments { get; set; }
        public virtual ICollection<DayVisit> DayVisits { get; set; }
        public virtual ICollection<EventPayment> EventPayments { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<RoomPayment> RoomPayments { get; set; }
    }
}
