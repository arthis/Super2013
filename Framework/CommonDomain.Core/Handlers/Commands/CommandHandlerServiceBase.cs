using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public abstract class CommandHandlerServiceBase : ICommandHandlerService
    {
        protected readonly Dictionary<Type, Func<ICommand, CommandValidation>> _handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();
        protected readonly Dictionary<Type, Action<IEvent>> _ports = new Dictionary<Type, Action<IEvent>>();
        
        public abstract void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory sessionFactory);
        public abstract void Subscribe(IBus bus);
        
        public  CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForMessageNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }

        public void Port(IEvent evt)
        {
            Contract.Requires(evt != null);

            var type = evt.GetType();
            if (_ports.ContainsKey(type))
                _ports[type](evt);
            else
                throw new HandlerForMessageNotFoundException(string.Format("No handler found for the event '{0}'", evt.GetType()));
        }
    }
}