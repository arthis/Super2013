using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface IEventBuilder<TEvent> where TEvent : IMessage
    {
        TEvent Build(Guid id, Guid commitId);
    }
}
