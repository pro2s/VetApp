using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VetApp.Models
{
    public class Person
    {

        public int ID { get; set; }

        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Confirmed { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<ApplicationUser> Accounts { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}