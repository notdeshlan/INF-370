using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RoomTypePrice
    {
        public int RoomPriceId { get; set; }
        public int? RoomTypeId { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }

        public virtual RoomType? RoomType { get; set; }
    }
}
