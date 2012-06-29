using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class CommandAlreadyProcessedException : Exception
    {
        public CommandAlreadyProcessedException(string msg)
            :base(msg)
        {
            
        }
    }
}
