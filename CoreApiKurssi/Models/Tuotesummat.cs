using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiKurssi.Models
{
    public partial class Tuotesummat
    {
        public int TuoteId { get; set; }
        public decimal? Summa { get; set; }
    }
}
