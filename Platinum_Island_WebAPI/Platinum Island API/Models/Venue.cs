using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Venue
    {
        public Venue()
        {
            VenueDateTimes = new HashSet<VenueDateTime>();
            VenueInspections = new HashSet<VenueInspection>();
            VenuePrices = new HashSet<VenuePrice>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; } = null!;
        public string VenueDescription { get; set; } = null!;
        public int Capacity { get; set; }

        public virtual ICollection<VenueDateTime> VenueDateTimes { get; set; }
        public virtual ICollection<VenueInspection> VenueInspections { get; set; }
        public virtual ICollection<VenuePrice> VenuePrices { get; set; }
    }
}
