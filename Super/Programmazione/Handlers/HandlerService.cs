using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Handlers.Commands.Plan;
using Super.Programmazione.Handlers.Commands.Scenario;
using Super.Programmazione.Handlers.Ports.Plan;

namespace Super.Programmazione.Handlers
{
    public class HandlerService : CommandHandlerServiceBase
    {

        public override void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, sessionFactory, _handlers);


            handlerHelper.Add( new CancelScenarioHandler(eventRepository, sessionFactory));
            handlerHelper.Add( new ChangeDescriptionScenarioHandler(eventRepository));
            handlerHelper.Add( new CreateScenarioHandler(eventRepository, sessionFactory));
            handlerHelper.Add( new PromoteScenarioToPlanHandler(eventRepository, sessionFactory));

            
            handlerHelper.Add( new CreatePlanFromPromotedScenarioHandler(eventRepository));

            
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            var portHelper = new PortHandlerHelper();
            portHelper.Add(_ports, new ScenarioPromotedToPlanHandler());

        }

    }

}
