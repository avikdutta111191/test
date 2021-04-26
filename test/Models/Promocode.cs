using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Promocode
    {
        public Guid Promocodeid { get; set; }
        public string Website { get; set; }
        public string Promocode1 { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public double Amount { get; set; }
        public int MaxCount { get; set; }
    }

    public class SearchPromocode
    {
        private List<Promocode> Promocode_list = null;
        public SearchPromocode()
        {
            if (Promocode_list == null)
                Promocode_list = new List<Promocode>();
        }

        public List<Promocode> PhoneList
        { get { return (Promocode_list != null) ? Promocode_list : null; } }
    }
}
