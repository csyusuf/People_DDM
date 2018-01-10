using People.Domain.Interfaces;
using People.Domain.Models;
using People.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Infrastructure.Data.Repository
{
    public class PersonRepository : Repository<PersonModel>, IPersonRepository
    {
        public PersonRepository(PeopleContext context) : base(context)
        {
     
        }
    }
}
