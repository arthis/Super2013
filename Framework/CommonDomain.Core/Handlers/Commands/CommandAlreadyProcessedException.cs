using System;

namespace CommonDomain.Core.Handlers.Commands
{
    public class CommandAlreadyProcessedException : Exception
    {
        public CommandAlreadyProcessedException(string msg)
            :base(msg)
        {
            
        }
    }
}
