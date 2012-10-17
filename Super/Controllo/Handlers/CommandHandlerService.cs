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
    public class CommandHandlerService<TSession> : CommandHandlerServiceBase<TSession> where TSession : ISession
    {

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper<TSession>(commandRepository, sessionFactory, _handlers);

            handlerHelper.Add(new AllowControlInterventoHandler(eventRepository));
            handlerHelper.Add( new CloseInterventoHandler(eventRepository));
            handlerHelper.Add( new ControlResoInterventoNonHandler(eventRepository));
            handlerHelper.Add( new ControlInterventoAmbResoHandler(eventRepository));
            handlerHelper.Add( new ControlResoInterventoRotHandler(eventRepository));
            handlerHelper.Add( new ControlResoInterventoRotManHandler(eventRepository));
            handlerHelper.Add( new ReopenInterventoHandler(eventRepository));
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<AllowControlIntervento>(subscriptionId, cmd => Execute(cmd));
        }

    }

}
