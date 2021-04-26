using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Movies
    {
        public Movies()
        {
            Moviehallshowtime = new HashSet<Moviehallshowtime>();
            Ticket = new HashSet<Ticket>();
        }

        public Guid Moviesid { get; set; }
        public string Mname { get; set; }

        public virtual ICollection<Moviehallshowtime> Moviehallshowtime { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
