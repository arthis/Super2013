﻿using System;
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
    public class CommandHandlerService : CommandHandlerServiceBase
    {

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, sessionFactory);

            handlerHelper.Add<AllowControlIntervento>(_handlers, new AllowControlInterventoHandler(eventRepository));
            handlerHelper.Add<CloseIntervento>(_handlers, new CloseInterventoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoNonReso>(_handlers, new ControlInterventoNonResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoAmbReso>(_handlers, new ControlInterventoAmbResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoRotReso>(_handlers, new ControlInterventoRotResoHandler(eventRepository));
            handlerHelper.Add<ControlInterventoRotManReso>(_handlers, new ControlInterventoRotManResoHandler(eventRepository));
            handlerHelper.Add<ReopenIntervento>(_handlers, new ReopenInterventoHandler(eventRepository));
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            bus.Subscribe<AllowControlIntervento>(subscriptionId, cmd => Execute(cmd));
        }

    }

}
