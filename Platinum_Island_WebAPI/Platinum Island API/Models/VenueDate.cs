using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenueDate
    {
        public VenueDate()
        {
            VenueDateTimes = new HashSet<VenueDateTime>();
        }

        public int VenueDateId { get; set; }
        public DateTime? VenueDate1 { get; set; }

        public virtual ICollection<VenueDateTime> VenueDateTimes { get; set; }
    }
}
