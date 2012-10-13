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

namespace Super.Controllo.Handlers
{
    public class CommandHandlerService<TSession> : CommandHandlerServiceBase<TSession> where TSession : ISession
    {

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper<TSession>(commandRepository, sessionFactory, _handlers);

            handlerHelper.Add(new AllowControlInterventoHandler(eventRepository));
            handlerHelper.Add( new CloseInterventoHandler(eventRepository));
            handlerHelper.Add( new ControlInterventoNonResoHandler(eventRepository));
            handlerHelper.Add( new ControlInterventoAmbResoHandler(eventRepository));
            handlerHelper.Add( new ControlInterventoRotResoHandler(eventRepository));
            handlerHelper.Add( new ControlInterventoRotManResoHandler(eventRepository));
            handlerHelper.Add( new ReopenInterventoHandler(eventRepository));
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<AllowControlIntervento>(subscriptionId, cmd => Execute(cmd));
        }

    }

}
