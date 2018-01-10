using People.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Commands
{
   public abstract class PersonCommand : Command
    {
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Gender { get; protected set; }
        public int Age { get; protected set; }
    }
}
