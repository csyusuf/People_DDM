using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Commands
{
    public class CreateNewPersonCommand : PersonCommand
    {
        public CreateNewPersonCommand(string firstName, string lastName, string gender, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
