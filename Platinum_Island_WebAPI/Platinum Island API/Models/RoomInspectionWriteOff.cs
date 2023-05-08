using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomInspectionWriteOff
    {
        public int ItemId { get; set; }
        public int InspectionId { get; set; }
        public string WriteOffDescription { get; set; } = null!;
        public byte[] WriteOffImage { get; set; } = null!;

        public virtual RoomInspection Inspection { get; set; } = null!;
        public virtual Item Item { get; set; } = null!;
    }
}
