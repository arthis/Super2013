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

        public void InitHandlers(IRepository repositoryEvent)
        {
            CustomHandler.Add<AllowControlIntervento>(_handlers, new AllowControlInterventoHandler(repositoryEvent));
            CustomHandler.Add<CloseIntervento>(_handlers, new CloseInterventoHandler(repositoryEvent));
            CustomHandler.Add<ControlInterventoNonReso>(_handlers, new ControlInterventoNonResoHandler(repositoryEvent));
            CustomHandler.Add<ControlInterventoAmbReso>(_handlers, new ControlInterventoAmbResoHandler(repositoryEvent));
            CustomHandler.Add<ControlInterventoRotReso>(_handlers, new ControlInterventoRotResoHandler(repositoryEvent));
            CustomHandler.Add<ControlInterventoRotManReso>(_handlers, new ControlInterventoRotManResoHandler(repositoryEvent));
            CustomHandler.Add<ReopenIntervento>(_handlers, new ReopenInterventoHandler(repositoryEvent));
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
