using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomStatus
    {
        public RoomStatus()
        {
            RoomDateTimes = new HashSet<RoomDateTime>();
        }

        public int RoomStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<RoomDateTime> RoomDateTimes { get; set; }
    }
}
