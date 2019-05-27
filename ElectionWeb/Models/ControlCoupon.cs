using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class ControlCoupon
    {
        public int Id { get; set; }
        public int ElectionId { get; set; }
        public int CityId { get; set; }
        public int VoterId { get; set; }

        public City City { get; set; }
        public Election Election { get; set; }
        public Voter Voter { get; set; }
    }
}
