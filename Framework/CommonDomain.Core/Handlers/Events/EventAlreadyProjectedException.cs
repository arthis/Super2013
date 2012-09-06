using System;

namespace CommonDomain.Core.Handlers.Events
{
    public class EventAlreadyProjectedException : Exception
    {
        public EventAlreadyProjectedException(string msg)
            : base(msg)
        {

        }
    }
}