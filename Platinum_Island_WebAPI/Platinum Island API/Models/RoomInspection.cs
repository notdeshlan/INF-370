using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomInspection
    {
        public RoomInspection()
        {
            RoomInspectionWriteOffs = new HashSet<RoomInspectionWriteOff>();
        }

        public int RoomInspectionId { get; set; }
        public int? RoomId { get; set; }
        public int? EmployeeId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? InspectionDate { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Room? Room { get; set; }
        public virtual InspectionStatus? Status { get; set; }
        public virtual ICollection<RoomInspectionWriteOff> RoomInspectionWriteOffs { get; set; }
    }
}
