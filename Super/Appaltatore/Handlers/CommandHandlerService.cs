using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;

namespace Super.Appaltatore.Handlers
{
    public class CommandHandlerService : CommandHandlerServiceBase
    {
        

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepositoryEvent)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository);

            handlerHelper.Add(_handlers, new ProgrammareInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ProgrammareInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ProgrammareInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add(_handlers, new ConsuntivareAmbNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotManNonResoHandler(eventRepositoryEvent));

            handlerHelper.Add(_handlers, new ConsuntivareAmbResoHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotResoHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotManResoHandler(eventRepositoryEvent));

            handlerHelper.Add(_handlers, new ConsuntivareAmbNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add(_handlers, new ConsuntivareRotManNonResoTrenitaliaHandler(eventRepositoryEvent));
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<ProgrammareInterventoRot>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoRotMan>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgrammareInterventoAmb>(subscriptionId, cmd => Execute(cmd));
        }


    }
}
