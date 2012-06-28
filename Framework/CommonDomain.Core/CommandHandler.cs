using System;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : IMessage
    {
        protected IRepository Repository;
        public abstract CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next);

        public CommandHandler(IRepository repository)
        {
            Contract.Requires<ArgumentNullException>(repository != null);

            Repository = repository;
        }
    }
}
