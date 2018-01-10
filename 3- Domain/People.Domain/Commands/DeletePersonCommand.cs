using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Commands
{
    public class DeletePersonCommand : PersonCommand
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
