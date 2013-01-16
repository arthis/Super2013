using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain
{
    public interface IEvent : IMessage
    {
        long Version { get; }  
    }
}
