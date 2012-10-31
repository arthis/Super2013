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
using Super.Appaltatore.Commands.Programmazione;

namespace Super.Appaltatore.Handlers
{
    public class CommandHandlerService : CommandHandlerServiceBase
    {
        private readonly ISecurityUserRepository _repo;

        public CommandHandlerService(ISecurityUserRepository repo)
        {
            _repo = repo;
        }

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepositoryEvent,IActionFactory actionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, actionFactory,_repo, Handlers);

            handlerHelper.Add( new ProgramInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgramInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add( new ProgramInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add(new ConsuntivareNonResoInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareNonResoInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareNonResoInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add(new ConsuntivareAutomaticamenteNonResoInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareAutomaticamenteNonResoInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareAutomaticamenteNonResoInterventoRotManHandler(eventRepositoryEvent));


            handlerHelper.Add( new ConsuntivareResoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareResoRotHandler(eventRepositoryEvent));
            handlerHelper.Add( new ConsuntivareResoRotManHandler(eventRepositoryEvent));

            handlerHelper.Add( new ConsuntivareNonResoTrenitaliaInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareNonResoTrenitaliaInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.Add(new ConsuntivareNonResoTrenitaliaInterventoRotManHandler(eventRepositoryEvent));
            
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
