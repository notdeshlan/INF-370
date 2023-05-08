using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class InspectionStatus
    {
        public InspectionStatus()
        {
            RoomInspections = new HashSet<RoomInspection>();
            VenueInspections = new HashSet<VenueInspection>();
        }

        public int InspectionStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<RoomInspection> RoomInspections { get; set; }
        public virtual ICollection<VenueInspection> VenueInspections { get; set; }
    }
}
