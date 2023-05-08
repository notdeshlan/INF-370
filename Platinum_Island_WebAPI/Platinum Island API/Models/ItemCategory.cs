using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            ItemTypes = new HashSet<ItemType>();
        }

        public int ItemCategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string CategoryDescription { get; set; } = null!;

        public virtual ICollection<ItemType> ItemTypes { get; set; }
    }
}
