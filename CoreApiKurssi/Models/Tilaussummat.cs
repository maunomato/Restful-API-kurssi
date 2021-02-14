using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiKurssi.Models
{
    public partial class Tilaussummat
    {
        public int OrderId { get; set; }
        public decimal? Summa { get; set; }
    }
}
