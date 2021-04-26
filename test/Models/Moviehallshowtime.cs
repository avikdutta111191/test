using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Moviehallshowtime
    {
        public Moviehallshowtime()
        {
            Ticket = new HashSet<Ticket>();
        }

        public Guid Moviehallshowtime1 { get; set; }
        public Guid Moviehallid { get; set; }
        public Guid Moviesid { get; set; }
        public DateTime Showtime { get; set; }

        public virtual Moviehall Moviehall { get; set; }
        public virtual Movies Movies { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
