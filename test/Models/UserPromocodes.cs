using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class UserPromocodes
    {
        public Guid Id { get; set; }
        public Guid Userid { get; set; }
        public Guid Promocodeid { get; set; }
        public double Value { get; set; }
    }
}
