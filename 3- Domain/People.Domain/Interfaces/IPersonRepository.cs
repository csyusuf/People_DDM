using People.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Interfaces
{
    public interface IPersonRepository : IRepository<PersonModel>
    {
    }
}
