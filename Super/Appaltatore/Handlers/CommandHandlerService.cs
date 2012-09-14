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
        

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepositoryEvent,ISessionFactory sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, sessionFactory, _handlers);

            handlerHelper.Add( new ProgrammareInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgrammareInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgrammareInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareAmbNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotNonResoHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotManNonResoHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareAmbResoHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotResoHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotManResoHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareAmbNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotNonResoTrenitaliaHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareRotManNonResoTrenitaliaHandler(eventRepositoryEvent));
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
