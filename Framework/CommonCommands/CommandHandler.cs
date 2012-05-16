using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace CommonCommands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        protected IRepository Repository;
        public abstract CommandValidation Execute(TCommand command);

        public CommandHandler(IRepository repository)
        {
            Contract.Requires<ArgumentNullException>(repository != null);

            Repository = repository;
        }
    }
}
