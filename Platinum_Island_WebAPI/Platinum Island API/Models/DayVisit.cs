using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class DayVisit
    {
        public DayVisit()
        {
            DayVisitPayments = new HashSet<DayVisitPayment>();
            DayVisitRefunds = new HashSet<DayVisitRefund>();
            DayVisitTickets = new HashSet<DayVisitTicket>();
            Reviews = new HashSet<Review>();
        }

        public int DayVisitId { get; set; }
        public int? DayVisitStatusId { get; set; }
        public int? ClientId { get; set; }
        public int? DayVisitDateId { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal Total { get; set; }

        public virtual Client? Client { get; set; }
        public virtual DayVisitDate? DayVisitDate { get; set; }
        public virtual DayVisitStatus? DayVisitStatus { get; set; }
        public virtual ICollection<DayVisitPayment> DayVisitPayments { get; set; }
        public virtual ICollection<DayVisitRefund> DayVisitRefunds { get; set; }
        public virtual ICollection<DayVisitTicket> DayVisitTickets { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
