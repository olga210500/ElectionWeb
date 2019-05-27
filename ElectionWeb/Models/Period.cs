using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Period
    {
        public Period()
        {
            Election = new HashSet<Election>();
        }

        public DateTime DatetimeStart { get; set; }
        public DateTime DatetimeEnd { get; set; }
        public int Id { get; set; }

        public ICollection<Election> Election { get; set; }
    }
}
