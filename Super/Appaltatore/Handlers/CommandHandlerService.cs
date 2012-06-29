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

        public void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepositoryEvent)
        {
            var handlerHelper = new HandlerHelper(commandRepository);

            handlerHelper.Add<ProgrammareInterventoAmb>(_handlers, new ProgrammareInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add<ProgrammareInterventoRot>(_handlers, new ProgrammareInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add<ProgrammareInterventoRotMan>(_handlers, new ProgrammareInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add<ConsuntivareAmbNonReso>(_handlers, new ConsuntivareAmbNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotNonReso>(_handlers, new ConsuntivareRotNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotManNonReso>(_handlers, new ConsuntivareRotManNonResoHandler(eventRepositoryEvent));

            handlerHelper.Add<ConsuntivareAmbReso>(_handlers, new ConsuntivareAmbResoHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotReso>(_handlers, new ConsuntivareRotResoHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotManReso>(_handlers, new ConsuntivareRotManResoHandler(eventRepositoryEvent));

            handlerHelper.Add<ConsuntivareAmbNonResoTrenitalia>(_handlers, new ConsuntivareAmbNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotNonResoTrenitalia>(_handlers, new ConsuntivareRotNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add<ConsuntivareRotManNonResoTrenitalia>(_handlers, new ConsuntivareRotManNonResoTrenitaliaHandler(eventRepositoryEvent));
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
