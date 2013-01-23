using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers.Commands
{
    public abstract class CommandHandlerServiceBase : ICommandHandlerService
    {
        
        protected readonly Dictionary<Type, Func<ICommand,  CommandValidation>> Handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();
        protected readonly Dictionary<Type, Func<IEvent,ICommand>> _ports = new Dictionary<Type, Func<IEvent,ICommand>>();



        public abstract void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, IActionHandler actionHandler);
        public abstract void Subscribe(IBus bus);
        
        public  CommandValidation Execute(ICommand commandBase)
        {
            

            var type = commandBase.GetType();
            if (Handlers.ContainsKey(type))
                return Handlers[type](commandBase);

            throw new HandlerForMessageNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }

        public void PortAndExecute(IEvent evt)
        {
            Contract.Requires(evt != null);

            var type = evt.GetType();
            if (_ports.ContainsKey(type))
            {
                var cmd = _ports[type](evt);
                Execute(cmd);
            }
            else
                throw new HandlerForMessageNotFoundException(string.Format("No handler found for the event '{0}'", evt.GetType()));
        }
    }
}