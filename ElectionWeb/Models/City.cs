using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
            Bulletin = new HashSet<Bulletin>();
            ControlCoupon = new HashSet<ControlCoupon>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }

        public ICollection<Address> Address { get; set; }
        public ICollection<Bulletin> Bulletin { get; set; }
        public ICollection<ControlCoupon> ControlCoupon { get; set; }
    }
}
