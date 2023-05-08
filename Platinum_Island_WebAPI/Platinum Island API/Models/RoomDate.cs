using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomDate
    {
        public RoomDate()
        {
            RoomDateTimes = new HashSet<RoomDateTime>();
        }

        public int RoomDateId { get; set; }
        public DateTime? RoomDate1 { get; set; }

        public virtual ICollection<RoomDateTime> RoomDateTimes { get; set; }
    }
}
