using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Bulletin
    {
        public int Id { get; set; }
        public int ElectionId { get; set; }
        public int CityId { get; set; }
        public int CandidateId { get; set; }

        public Candidate Candidate { get; set; }
        public City City { get; set; }
        public Election Election { get; set; }
    }
}
