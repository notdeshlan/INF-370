using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitStatus
    {
        public DayVisitStatus()
        {
            DayVisits = new HashSet<DayVisit>();
        }

        public int DayVisitStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<DayVisit> DayVisits { get; set; }
    }
}
