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
        private readonly Dictionary<Type, Func<Object, CommandValidation>> _handlers = new Dictionary<Type, Func<Object, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(AllowControlIntervento),
                          (cmd) => new AllowControlInterventoHandler(repositoryEvent).Execute((AllowControlIntervento)cmd));

            _handlers.Add(typeof(CloseIntervento),
                          (cmd) => new CloseInterventoHandler(repositoryEvent).Execute((CloseIntervento)cmd));

            _handlers.Add(typeof(ControlInterventoNonReso),
                          (cmd) => new ControlInterventoNonResoHandler(repositoryEvent).Execute((ControlInterventoNonReso)cmd));
            
            _handlers.Add(typeof(ControlInterventoAmbReso),
                          (cmd) => new ControlInterventoAmbResoHandler(repositoryEvent).Execute((ControlInterventoAmbReso)cmd));
            _handlers.Add(typeof(ControlInterventoRotReso),
                          (cmd) => new ControlInterventoRotResoHandler(repositoryEvent).Execute((ControlInterventoRotReso)cmd));
            _handlers.Add(typeof(ControlInterventoRotManReso),
                          (cmd) => new ControlInterventoRotManResoHandler(repositoryEvent).Execute((ControlInterventoRotManReso)cmd));

            _handlers.Add(typeof(ReopenIntervento),
                         (cmd) => new ReopenInterventoHandler(repositoryEvent).Execute((ReopenIntervento)cmd));
            
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
