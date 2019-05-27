using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Candidate
    {
        public Candidate()
        {
            Bulletin = new HashSet<Bulletin>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ElectionId { get; set; }
        public string PreelectionProgram { get; set; }

        public Election Election { get; set; }
        public Person Person { get; set; }
        public ICollection<Bulletin> Bulletin { get; set; }

        public override string ToString()
        {
            return PreelectionProgram;
        }
    }
}
