using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            RoomTypePrices = new HashSet<RoomTypePrice>();
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;
        public int RoomCapacity { get; set; }

        public virtual ICollection<RoomTypePrice> RoomTypePrices { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
