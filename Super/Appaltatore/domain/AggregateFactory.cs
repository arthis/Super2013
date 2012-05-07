using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using CommonDomain;

namespace example1
{
    public class AggregateFactory : IConstructAggregates
    {
        public IAggregate Build(Type type, Guid id, IMemento snapshot)
        {
            //if (type == typeof(IMyInterface))
            //    return new MyAggregate();
            //else
                return Activator.CreateInstance(type) as IAggregate;
        }
    }


}
