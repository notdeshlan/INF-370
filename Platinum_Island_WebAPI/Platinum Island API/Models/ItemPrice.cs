using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class ItemPrice
    {
        public int ItemPriceId { get; set; }
        public int? ItemId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PriceDate { get; set; }

        public virtual Item? Item { get; set; }
    }
}
