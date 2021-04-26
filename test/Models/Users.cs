using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Users
    {
        public Users()
        {
            Ticket = new HashSet<Ticket>();
        }

        public Guid Userid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Uname { get; set; }
        public string Passwd { get; set; }
        public double? Balance { get; set; }
        public double? Payout { get; set; }

        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}
