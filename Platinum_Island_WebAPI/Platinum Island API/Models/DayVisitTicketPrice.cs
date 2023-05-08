using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisitTicketPrice
    {
        public int PriceId { get; set; }
        public int? TicketId { get; set; }
        public int LowerAge { get; set; }
        public int UpperAge { get; set; }
        public decimal Price { get; set; }
        public DateTime? PriceDate { get; set; }

        public virtual DayVisitTicket? Ticket { get; set; }
    }
}
