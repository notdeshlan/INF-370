using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class EventTicket
    {
        public int TicketId { get; set; }
        public int? EventId { get; set; }
        public string GuestName { get; set; } = null!;
        public int GuestAge { get; set; }
        public byte[] QrCode { get; set; } = null!;

        public virtual Event? Event { get; set; }
    }
}
