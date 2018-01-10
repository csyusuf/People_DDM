using People.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Models
{
    public class PersonModel : Entity
    {
        public PersonModel() { }

        public PersonModel(string firstName, string lastName, string gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
