using System;
using System.Collections.Generic;

#nullable disable

namespace KPZ_LAB_3.Repository.Models
{
    public partial class PersonDatum
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
