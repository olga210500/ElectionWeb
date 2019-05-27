using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Voter
    {
        public Voter()
        {
            ControlCoupon = new HashSet<ControlCoupon>();
        }

        public int Id { get; set; }
        public int ElectionId { get; set; }
        public int PersonId { get; set; }

        public Election Election { get; set; }
        public Person Person { get; set; }
        public ICollection<ControlCoupon> ControlCoupon { get; set; }
    }
}
