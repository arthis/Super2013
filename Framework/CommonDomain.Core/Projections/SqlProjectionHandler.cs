using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Projections
{
    public class SqlProjectionHandler<T> :IEventProjectionHandler<T> where T:IEvent
    {
        public SqlProjectionHandler(IEnumerable<IProjectionAction> projections)
        {

        }

        public void Handle(T evt)
        {
            throw new NotImplementedException();
        }
    }
}
