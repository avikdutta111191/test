using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Ticket
    {
        public Guid Ticketid { get; set; }
        public Guid Moviesid { get; set; }
        public Guid Moviehallid { get; set; }
        public Guid Userid { get; set; }
        public Guid Priceid { get; set; }
        public Guid Moviehallshowtime { get; set; }

        public virtual Moviehall Moviehall { get; set; }
        public virtual Moviehallshowtime MoviehallshowtimeNavigation { get; set; }
        public virtual Movies Movies { get; set; }
        public virtual Price Price { get; set; }
        public virtual Users User { get; set; }
    }
}
