using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;

namespace Super.Appaltatore.Handlers
{
    public class CommandHandlerService : ICommandHandlerService
    {
        private readonly Dictionary<Type, Func<Object, CommandValidation>> _handlers = new Dictionary<Type, Func<Object, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            _handlers.Add(typeof(ProgrammareInterventoAmb),
                          (cmd) => new ProgrammareInterventoAmbHandler(repositoryEvent).Execute((ProgrammareInterventoAmb)cmd));
            _handlers.Add(typeof(ProgrammareInterventoRot),
                          (cmd) => new ProgrammareInterventoRotHandler(repositoryEvent).Execute((ProgrammareInterventoRot)cmd));
            _handlers.Add(typeof(ProgrammareInterventoRotMan),
                          (cmd) => new ProgrammareInterventoRotManHandler(repositoryEvent).Execute((ProgrammareInterventoRotMan)cmd));

            _handlers.Add(typeof(ConsuntivareAmbNonReso),
                          (cmd) => new ConsuntivareAmbNonResoHandler(repositoryEvent).Execute((ConsuntivareAmbNonReso)cmd));
            _handlers.Add(typeof(ConsuntivareRotNonReso),
                          (cmd) => new ConsuntivareRotNonResoHandler(repositoryEvent).Execute((ConsuntivareRotNonReso)cmd));
            _handlers.Add(typeof(ConsuntivareRotManNonReso),
                          (cmd) => new ConsuntivareRotManNonResoHandler(repositoryEvent).Execute((ConsuntivareRotManNonReso)cmd));

            _handlers.Add(typeof(ConsuntivareAmbReso),
                          (cmd) => new ConsuntivareAmbResoHandler(repositoryEvent).Execute((ConsuntivareAmbReso)cmd));
            _handlers.Add(typeof(ConsuntivareRotReso),
                          (cmd) => new ConsuntivareRotResoHandler(repositoryEvent).Execute((ConsuntivareRotReso)cmd));
            _handlers.Add(typeof(ConsuntivareRotManReso),
                          (cmd) => new ConsuntivareRotManResoHandler(repositoryEvent).Execute((ConsuntivareRotManReso)cmd));

            _handlers.Add(typeof(ConsuntivareAmbNonResoTrenitalia),
                          (cmd) => new ConsuntivareAmbNonResoTrenitaliaHandler(repositoryEvent).Execute((ConsuntivareAmbNonResoTrenitalia)cmd));
            _handlers.Add(typeof(ConsuntivareRotNonResoTrenitalia),
                          (cmd) => new ConsuntivareRotNonResoTrenitaliaHandler(repositoryEvent).Execute((ConsuntivareRotNonResoTrenitalia)cmd));
            _handlers.Add(typeof(ConsuntivareRotManNonResoTrenitalia),
                          (cmd) => new ConsuntivareRotManNonResoTrenitaliaHandler(repositoryEvent).Execute((ConsuntivareRotManNonResoTrenitalia)cmd));
        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<ProgrammareInterventoRot>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoRotMan>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoAmb>(subscriptionId, cmd => Execute(cmd));
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
