using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class AuditLog
    {
        public int AuditLogId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? DateOfChange { get; set; }
        public TimeSpan? TimeOfChange { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
