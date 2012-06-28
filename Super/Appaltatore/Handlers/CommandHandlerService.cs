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


        private readonly Dictionary<Type, Func<IMessage, CommandValidation>> _handlers = new Dictionary<Type, Func<IMessage, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            TypicalHandler.Add<ProgrammareInterventoAmb>(_handlers, new ProgrammareInterventoAmbHandler(repositoryEvent));
            TypicalHandler.Add<ProgrammareInterventoRot>(_handlers, new ProgrammareInterventoRotHandler(repositoryEvent));
            TypicalHandler.Add<ProgrammareInterventoRotMan>(_handlers, new ProgrammareInterventoRotManHandler(repositoryEvent));

            TypicalHandler.Add<ConsuntivareAmbNonReso>(_handlers, new ConsuntivareAmbNonResoHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotNonReso>(_handlers, new ConsuntivareRotNonResoHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotManNonReso>(_handlers, new ConsuntivareRotManNonResoHandler(repositoryEvent));

            TypicalHandler.Add<ConsuntivareAmbReso>(_handlers, new ConsuntivareAmbResoHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotReso>(_handlers, new ConsuntivareRotResoHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotManReso>(_handlers, new ConsuntivareRotManResoHandler(repositoryEvent));

            TypicalHandler.Add<ConsuntivareAmbNonResoTrenitalia>(_handlers, new ConsuntivareAmbNonResoTrenitaliaHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotNonResoTrenitalia>(_handlers, new ConsuntivareRotNonResoTrenitaliaHandler(repositoryEvent));
            TypicalHandler.Add<ConsuntivareRotManNonResoTrenitalia>(_handlers, new ConsuntivareRotManNonResoTrenitaliaHandler(repositoryEvent));
        }

        public void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<ProgrammareInterventoRot>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoRotMan>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoAmb>(subscriptionId, cmd => Execute(cmd));
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
