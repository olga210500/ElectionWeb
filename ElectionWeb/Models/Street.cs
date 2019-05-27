using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Street
    {
        public Street()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Street1 { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
