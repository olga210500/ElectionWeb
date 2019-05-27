using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Election
    {
        public Election()
        {
            Bulletin = new HashSet<Bulletin>();
            Candidate = new HashSet<Candidate>();
            ControlCoupon = new HashSet<ControlCoupon>();
            Voter = new HashSet<Voter>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NationId { get; set; }
        public int PeriodId { get; set; }
        public short Tour { get; set; }

        public Nation Nation { get; set; }
        public Period Period { get; set; }
        public ICollection<Bulletin> Bulletin { get; set; }
        public ICollection<Candidate> Candidate { get; set; }
        public ICollection<ControlCoupon> ControlCoupon { get; set; }
        public ICollection<Voter> Voter { get; set; }
    }
}
