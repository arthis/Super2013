using System;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : IMessage
    {
        protected IEventRepository EventRepository;

        public abstract CommandValidation Execute(TCommand command);

        public CommandHandler(IEventRepository eventRepository)
        {
            Contract.Requires<ArgumentNullException>(eventRepository != null);

            EventRepository = eventRepository;
        }
    }
}
