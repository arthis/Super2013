using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Handlers.Commands.Scenario;

namespace Super.Programmazione.Handlers
{
    public class HandlerService : CommandHandlerServiceBase
    {

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, sessionFactory);


            handlerHelper.Add(_handlers, new CancelScenarioHandler(eventRepository, sessionFactory));
            handlerHelper.Add(_handlers, new ChangeDescriptionScenarioHandler(eventRepository));
            handlerHelper.Add(_handlers, new CreateScenarioHandler(eventRepository, sessionFactory));
            handlerHelper.Add(_handlers, new PromoteScenarioToPlanHandler(eventRepository, sessionFactory));

            
            
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            var portHelper = new PortHandlerHelper();

            portHelper.Add(_ports,);

            bus.Subscribe<ScenarioPromotedToPlan>(subscriptionId, Port);
        }

    }

}
