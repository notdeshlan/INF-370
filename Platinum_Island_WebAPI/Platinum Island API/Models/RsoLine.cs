using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class RsoLine
    {
        public int Rsoid { get; set; }
        public int OrderLineId { get; set; }
        public int QtyRecieved { get; set; }

        public virtual OrderLine OrderLine { get; set; } = null!;
        public virtual RecieveSupplierOrder Rso { get; set; } = null!;
    }
}
