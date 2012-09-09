using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public abstract class CommandHandlerServiceBase : ICommandHandlerService
    {
        protected readonly Dictionary<Type, Func<ICommand, CommandValidation>> _handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();
        
        public abstract void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository);
        public abstract void Subscribe(IBus bus);
        
        public  CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }
}