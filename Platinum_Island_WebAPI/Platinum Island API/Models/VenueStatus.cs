using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenueStatus
    {
        public VenueStatus()
        {
            VenueDateTimes = new HashSet<VenueDateTime>();
        }

        public int VenueStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<VenueDateTime> VenueDateTimes { get; set; }
    }
}
