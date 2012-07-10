using System;

namespace CommonDomain.Core.Handlers
{
    public class EventAlreadyProjectedException : Exception
    {
        public EventAlreadyProjectedException(string msg)
            : base(msg)
        {

        }
    }
}