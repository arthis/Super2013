using System;

namespace CommonDomain.Core.Handlers.Events
{
    public class EventAlreadyHandled : Exception
    {
        public EventAlreadyHandled(string msg)
            :base(msg)
        {
            
        }
    }
}