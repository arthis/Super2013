using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain
{
    public interface IEventBuilder< out TEvent> where TEvent : IEvent
    {
        TEvent Build(Guid id, long version);
    }

    
}
