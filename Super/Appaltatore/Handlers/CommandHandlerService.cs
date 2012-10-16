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
using Super.Appaltatore.Commands.Consuntivazione;

namespace Super.Appaltatore.Handlers
{
    public class CommandHandlerService<TSession> : CommandHandlerServiceBase <TSession> where TSession:ISession
    {
        

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepositoryEvent,ISessionFactory<TSession> sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper<TSession>(commandRepository, sessionFactory, _handlers);

            handlerHelper.Add( new ProgramInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgramInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgramInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareNonResoHandler(eventRepositoryEvent));
            

            handlerHelper.Add( new ConsuntivareResoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareResoRotHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareResoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareNonResoTrenitaliaHandler(eventRepositoryEvent));
            
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<ProgramInterventoRot>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgramInterventoRotMan>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgramInterventoAmb>(subscriptionId, cmd => Execute(cmd));
        }


    }
}
