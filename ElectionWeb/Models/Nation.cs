using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Nation
    {
        public Nation()
        {
            Election = new HashSet<Election>();
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Country { get; set; }

        public ICollection<Election> Election { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
