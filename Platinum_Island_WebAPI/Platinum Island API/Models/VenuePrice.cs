using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenuePrice
    {
        public int VenuePriceId { get; set; }
        public int? VenueId { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }

        public virtual Venue? Venue { get; set; }
    }
}
