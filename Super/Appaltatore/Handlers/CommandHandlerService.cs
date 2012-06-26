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


        private readonly Dictionary<Type, Func<ICommand, CommandValidation>> _handlers = new Dictionary<Type, Func<ICommand, CommandValidation>>();

        public void InitHandlers(IRepository repositoryEvent)
        {
            CustomHandler.Add<ProgrammareInterventoAmb>(_handlers, new ProgrammareInterventoAmbHandler(repositoryEvent));
            CustomHandler.Add<ProgrammareInterventoRot>(_handlers, new ProgrammareInterventoRotHandler(repositoryEvent));
            CustomHandler.Add<ProgrammareInterventoRotMan>(_handlers, new ProgrammareInterventoRotManHandler(repositoryEvent));

            CustomHandler.Add<ConsuntivareAmbNonReso>(_handlers, new ConsuntivareAmbNonResoHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotNonReso>(_handlers, new ConsuntivareRotNonResoHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotManNonReso>(_handlers, new ConsuntivareRotManNonResoHandler(repositoryEvent));

            CustomHandler.Add<ConsuntivareAmbReso>(_handlers, new ConsuntivareAmbResoHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotReso>(_handlers, new ConsuntivareRotResoHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotManReso>(_handlers, new ConsuntivareRotManResoHandler(repositoryEvent));

            CustomHandler.Add<ConsuntivareAmbNonResoTrenitalia>(_handlers, new ConsuntivareAmbNonResoTrenitaliaHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotNonResoTrenitalia>(_handlers, new ConsuntivareRotNonResoTrenitaliaHandler(repositoryEvent));
            CustomHandler.Add<ConsuntivareRotManNonResoTrenitalia>(_handlers, new ConsuntivareRotManNonResoTrenitaliaHandler(repositoryEvent));
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
