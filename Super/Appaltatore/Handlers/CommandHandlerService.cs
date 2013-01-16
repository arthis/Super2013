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

            handlerHelper.AddFullyConstrainedCommand( new ProgramInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand( new ProgramInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand( new ProgramInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareNonResoInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareNonResoInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareNonResoInterventoRotManHandler(eventRepositoryEvent));

            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareAutomaticamenteNonResoInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareAutomaticamenteNonResoInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareAutomaticamenteNonResoInterventoRotManHandler(eventRepositoryEvent));


            handlerHelper.AddFullyConstrainedCommand( new ConsuntivareResoAmbHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand( new ConsuntivareResoRotHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand( new ConsuntivareResoRotManHandler(eventRepositoryEvent));

            handlerHelper.AddFullyConstrainedCommand( new ConsuntivareNonResoTrenitaliaInterventoAmbHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareNonResoTrenitaliaInterventoRotHandler(eventRepositoryEvent));
            handlerHelper.AddFullyConstrainedCommand(new ConsuntivareNonResoTrenitaliaInterventoRotManHandler(eventRepositoryEvent));
            
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super_Appaltatore_Commands_";

            bus.Subscribe<ProgramInterventoRot>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgramInterventoRotMan>(subscriptionId, cmd => Execute(cmd));
            bus.Subscribe<ProgramInterventoAmb>(subscriptionId, cmd => Execute(cmd));
        }


    }
}
