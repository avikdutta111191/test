using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Moviehall
    {
        public Moviehall()
        {
            Moviehallshowtime = new HashSet<Moviehallshowtime>();
            Ticket = new HashSet<Ticket>();
        }

        public Guid Moviehallid { get; set; }
        public string Mhallname { get; set; }
        public int Totalseats { get; set; }
        public int Bookedseats { get; set; }
        public Guid Priceid { get; set; }

        public virtual Price Price { get; set; }
        public virtual ICollection<Moviehallshowtime> Moviehallshowtime { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
