using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class VenueInspection
    {
        public VenueInspection()
        {
            VenueInspectionWriteOffs = new HashSet<VenueInspectionWriteOff>();
        }

        public int VenueInspectionId { get; set; }
        public int? VenueId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? InspectionDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual InspectionStatus? Status { get; set; }
        public virtual Venue? Venue { get; set; }
        public virtual ICollection<VenueInspectionWriteOff> VenueInspectionWriteOffs { get; set; }
    }
}
