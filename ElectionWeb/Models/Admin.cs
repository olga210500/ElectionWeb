using System;
using System.Collections.Generic;

namespace ElectionWeb
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}
