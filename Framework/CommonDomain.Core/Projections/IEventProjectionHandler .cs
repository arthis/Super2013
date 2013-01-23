using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core.Projections
{
    public interface IEventProjectionHandler<TEvent> where TEvent : IMessage
    {
         void Handle(TEvent evt);
    }
}
