using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomDateTimes = new HashSet<RoomDateTime>();
            RoomInspections = new HashSet<RoomInspection>();
        }

        public int RoomId { get; set; }
        public int? RoomTypeId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomFloor { get; set; } = null!;

        public virtual RoomType? RoomType { get; set; }
        public virtual ICollection<RoomDateTime> RoomDateTimes { get; set; }
        public virtual ICollection<RoomInspection> RoomInspections { get; set; }
    }
}
