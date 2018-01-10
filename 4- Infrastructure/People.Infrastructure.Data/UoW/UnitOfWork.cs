using People.Domain.Interfaces;
using People.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using People.Domain.Core.Commands;

namespace People.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleContext context;

        public UnitOfWork(PeopleContext context)
        {
            this.context = context;
        }

        public CommandResponse Commit()
        {

            var rowsAffected = context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
