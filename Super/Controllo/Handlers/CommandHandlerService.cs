using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Controllo.Commands;

namespace Super.Controllo.Handlers
{
    public class CommandHandlerService : ICommandHandlerService
    {
        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();

        public void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository)
        {
            var handlerHelper = new HandlerHelper(commandRepository);

            handlerHelper.Add<AllowControlIntervento>(_handlers, new AllowControlInterventoHandler(eventRepository));
            handlerHelper.Add<CloseIntervento>(_handlers, new CloseInterventoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoNonReso>(_handlers, new ControlInterventoNonResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoAmbReso>(_handlers, new ControlInterventoAmbResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoRotReso>(_handlers, new ControlInterventoRotResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoRotManReso>(_handlers, new ControlInterventoRotManResoHandler(eventRepository));
            handlerHelper.Add<ReopenIntervento>(_handlers, new ReopenInterventoHandler(eventRepository));
        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<AllowControlIntervento>(subscriptionId, cmd => Execute(cmd));
        }


        public CommandValidation Execute(ICommand commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
