using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionWeb
{
    public class DataRangeAttribute : ValidationAttribute
    {
        private DateTime _beginDate;
        private DateTime _endDate;
        public DataRangeAttribute()
        {
            _beginDate = new DateTime(1900, 1, 1);
            _endDate = DateTime.Now;
        }

        public override bool IsValid(object value)
        {
            DateTime dateToValidate;
            DateTime.TryParse(value.ToString(), out dateToValidate);

            return dateToValidate > _beginDate && dateToValidate < _endDate;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(
                "У вказаному полі {0} введено неправильну дату , можлива дата народження в диапозоні {1} - {2}", name, _beginDate,
                _endDate);
        }
    }

    public partial class Person
    {
        public Person()
        {
            Admin = new HashSet<Admin>();
            Candidate = new HashSet<Candidate>();
            Voter = new HashSet<Voter>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataRange()]
        public DateTime BirthDate { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int CountryId { get; set; }

        public Address Address { get; set; }
        public Nation Country { get; set; }
        public ICollection<Admin> Admin { get; set; }
        public ICollection<Candidate> Candidate { get; set; }
        public ICollection<Voter> Voter { get; set; }
    }
}
