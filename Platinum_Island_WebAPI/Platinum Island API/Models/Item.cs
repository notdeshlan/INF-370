using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemPrices = new HashSet<ItemPrice>();
            OrderLines = new HashSet<OrderLine>();
            RoomInspectionWriteOffs = new HashSet<RoomInspectionWriteOff>();
            VenueInspectionWriteOffs = new HashSet<VenueInspectionWriteOff>();
        }

        public int ItemId { get; set; }
        public int? ItemTypeId { get; set; }
        public string ItemName { get; set; } = null!;
        public int QtyOnHand { get; set; }
        public string ItemDescription { get; set; } = null!;

        public virtual ItemType? ItemType { get; set; }
        public virtual ICollection<ItemPrice> ItemPrices { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<RoomInspectionWriteOff> RoomInspectionWriteOffs { get; set; }
        public virtual ICollection<VenueInspectionWriteOff> VenueInspectionWriteOffs { get; set; }
    }
}
