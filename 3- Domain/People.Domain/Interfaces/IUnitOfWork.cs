using People.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
