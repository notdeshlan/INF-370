using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenueTime
    {
        public VenueTime()
        {
            VenueDateTimes = new HashSet<VenueDateTime>();
        }

        public int VenueTimeId { get; set; }
        public TimeSpan? VenueTime1 { get; set; }

        public virtual ICollection<VenueDateTime> VenueDateTimes { get; set; }
    }
}
