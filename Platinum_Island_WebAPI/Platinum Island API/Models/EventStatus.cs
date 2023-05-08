using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EventStatus
    {
        public EventStatus()
        {
            Events = new HashSet<Event>();
        }

        public int EventStatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
