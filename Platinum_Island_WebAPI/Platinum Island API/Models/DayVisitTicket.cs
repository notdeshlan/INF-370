using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitTicket
    {
        public DayVisitTicket()
        {
            DayVisitTicketPrices = new HashSet<DayVisitTicketPrice>();
        }

        public int TicketId { get; set; }
        public int? DayVisitId { get; set; }
        public string GuestName { get; set; } = null!;
        public byte[] Qrcode { get; set; } = null!;
        public int GuestAge { get; set; }

        public virtual DayVisit? DayVisit { get; set; }
        public virtual ICollection<DayVisitTicketPrice> DayVisitTicketPrices { get; set; }
    }
}
