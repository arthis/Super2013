using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Controllo.Commands;
using Super.Controllo.Commands.Consuntivazione;


namespace Super.Controllo.Handlers
{
    public class CommandHandlerService : CommandHandlerServiceBase
    {
        private readonly ISecurityUserRepository _repositorySecurityUser;

        public CommandHandlerService(ISecurityUserRepository repositorySecurityUser)
        {
            _repositorySecurityUser = repositorySecurityUser;
        }

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, IActionHandler actionHandler)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, actionHandler, _repositorySecurityUser, Handlers);

            
            handlerHelper.AddFullyConstrainedCommand( new CloseInterventoHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ControlResoInterventoNonHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ControlInterventoAmbResoHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ControlResoInterventoRotHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ControlResoInterventoRotManHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ReopenInterventoHandler(eventRepository));
        }

        

        public override void Subscribe(IBus bus)
        {
            

            
        }

    }

}
