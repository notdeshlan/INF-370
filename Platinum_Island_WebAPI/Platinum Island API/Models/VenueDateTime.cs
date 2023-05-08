using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenueDateTime
    {
        public int DateId { get; set; }
        public int TimeId { get; set; }
        public int? VenueId { get; set; }
        public int? VenueStatusId { get; set; }
        public int? EventId { get; set; }

        public virtual VenueDate Date { get; set; } = null!;
        public virtual Event? Event { get; set; }
        public virtual VenueTime Time { get; set; } = null!;
        public virtual Venue? Venue { get; set; }
        public virtual VenueStatus? VenueStatus { get; set; }
    }
}
