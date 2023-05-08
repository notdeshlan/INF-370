using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public int ItemTypeId { get; set; }
        public int? ItemCategoryId { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeDescription { get; set; } = null!;

        public virtual ItemCategory? ItemCategory { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
