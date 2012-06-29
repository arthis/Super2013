using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonDomain.Core
{
    public class LogCommandPerfomanceHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next)
        {
            //do something to log the performance of the command 
            return next.Execute(command, null);
        }
    }
}
