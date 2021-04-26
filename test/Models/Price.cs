using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Price
    {
        public Price()
        {
            Moviehall = new HashSet<Moviehall>();
            Ticket = new HashSet<Ticket>();
        }

        public Guid Priceid { get; set; }
        public int Price1 { get; set; }
        public string PriceCategory { get; set; }

        public virtual ICollection<Moviehall> Moviehall { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
