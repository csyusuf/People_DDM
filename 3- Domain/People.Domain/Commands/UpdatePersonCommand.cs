using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Commands
{
    public class UpdatePersonCommand : PersonCommand
    {
        public UpdatePersonCommand(int id, string firstName, string lastName, string gender, int age)
        {
            Id = id;
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
