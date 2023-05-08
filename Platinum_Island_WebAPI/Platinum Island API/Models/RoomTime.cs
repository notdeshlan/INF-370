using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomTime
    {
        public RoomTime()
        {
            RoomDateTimes = new HashSet<RoomDateTime>();
        }

        public int RoomTimeId { get; set; }
        public TimeSpan? RoomTime1 { get; set; }

        public virtual ICollection<RoomDateTime> RoomDateTimes { get; set; }
    }
}
