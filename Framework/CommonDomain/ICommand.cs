using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain
{
    public interface ICommand : IMessage
    {
        long? Version { get; }
        DateTime? WakeTime { get; }
        bool IsExecuted { get; }
        Guid SecurityToken { get; }

        
    }
}
