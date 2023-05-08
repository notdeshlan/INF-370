using System;
using System.Collections.Generic;

namespace Platinum_Island_API.Models
{
    public partial class Vat
    {
        public int VatId { get; set; }
        public decimal VatAmount { get; set; }
        public DateTime? VatDate { get; set; }
    }
}
