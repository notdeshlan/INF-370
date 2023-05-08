using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitDate
    {
        public DayVisitDate()
        {
            DayVisits = new HashSet<DayVisit>();
        }

        public int DayVisitDateId { get; set; }
        public DateTime? DayVisitDate1 { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<DayVisit> DayVisits { get; set; }
    }
}
