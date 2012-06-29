﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : IMessage
    {
        protected IEventRepository EventRepository;
        public abstract CommandValidation Execute(TCommand command, ICommandHandler<TCommand> next);

        public CommandHandler(IEventRepository eventRepository)
        {
            Contract.Requires<ArgumentNullException>(eventRepository != null);

            EventRepository = eventRepository;
        }
    }
}
