using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ElectionWeb
{
    public partial class Address
    {
        public Address()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public int? RegionId { get; set; }
        public int CityId { get; set; }
        public int? StreetId { get; set; }

        [Required]
        public City City { get; set; }
        public Region Region { get; set; }
        public Street Street { get; set; }
        public ICollection<Person> Person { get; set; }
    }
}
