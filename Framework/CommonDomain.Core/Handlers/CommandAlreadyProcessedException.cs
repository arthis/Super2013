using System;

namespace CommonDomain.Core.Handlers
{
    public class CommandAlreadyProcessedException : Exception
    {
        public CommandAlreadyProcessedException(string msg)
            :base(msg)
        {
            
        }
    }
}
