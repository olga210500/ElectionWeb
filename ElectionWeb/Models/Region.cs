using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Region
    {
        public Region()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Region1 { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
