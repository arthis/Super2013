﻿using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Handlers.Commands
{
    public class LogCommandPerfomanceHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand 
    {
        private readonly ICommandHandler<TCommand> _next;

        public LogCommandPerfomanceHandler(ICommandHandler<TCommand> next)
        {
            Contract.Requires(next !=null);

            _next = next;
        }

        public CommandValidation Execute(TCommand command)
        {
            //do something to log the performance of the command 
            return _next.Execute(command);
        }
    }
}
