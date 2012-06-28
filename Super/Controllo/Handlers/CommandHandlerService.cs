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
        private readonly Dictionary<Type, Func<IMessage, CommandValidation>> _handlers = new Dictionary<Type, Func<IMessage, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            TypicalHandler.Add<AllowControlIntervento>(_handlers, new AllowControlInterventoHandler(repositoryEvent));
            TypicalHandler.Add<CloseIntervento>(_handlers, new CloseInterventoHandler(repositoryEvent));
            TypicalHandler.Add<ControlInterventoNonReso>(_handlers, new ControlInterventoNonResoHandler(repositoryEvent));
            TypicalHandler.Add<ControlInterventoAmbReso>(_handlers, new ControlInterventoAmbResoHandler(repositoryEvent));
            TypicalHandler.Add<ControlInterventoRotReso>(_handlers, new ControlInterventoRotResoHandler(repositoryEvent));
            TypicalHandler.Add<ControlInterventoRotManReso>(_handlers, new ControlInterventoRotManResoHandler(repositoryEvent));
            TypicalHandler.Add<ReopenIntervento>(_handlers, new ReopenInterventoHandler(repositoryEvent));
        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<AllowControlIntervento>(subscriptionId, cmd => Execute(cmd));
        }


        public CommandValidation Execute(IMessage commandBase)
        {
            Contract.Requires<ArgumentNullException>(commandBase != null);


            var type = commandBase.GetType();
            if (_handlers.ContainsKey(type))
                return _handlers[type](commandBase);

            throw new HandlerForDomainEventNotFoundException(string.Format("No handler found for the command '{0}'", commandBase.GetType()));
          
        }
    }

}
