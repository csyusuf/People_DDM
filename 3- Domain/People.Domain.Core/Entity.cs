using System;
using System.Collections.Generic;
using System.Text;

namespace People.Domain.Core
{
    public abstract class Entity
    {
        public int ID { get; protected set; }
    }
}
