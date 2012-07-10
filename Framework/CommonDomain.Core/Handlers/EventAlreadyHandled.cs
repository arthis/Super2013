using System;

namespace CommonDomain.Core.Handlers
{
    public class EventAlreadyHandled : Exception
    {
        public EventAlreadyHandled(string msg)
            :base(msg)
        {
            
        }
    }
}