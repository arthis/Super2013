using CommonDomain;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Handlers.Commands.Plan;
using Super.Programmazione.Handlers.Commands.Programma;
using Super.Programmazione.Handlers.Commands.Scenario;
using Super.Programmazione.Handlers.Ports.Plan;
using Super.Programmazione.Handlers.Ports.Programma;

namespace Super.Programmazione.Handlers
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


            handlerHelper.AddFullyConstrainedCommand( new CancelScenarioHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new ChangeDescriptionScenarioHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new CreateScenarioHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand( new PromoteScenarioToPlanHandler(eventRepository));

            #region programma

            handlerHelper.AddFullyConstrainedCommand( new AddSchedulazioneRotToProgrammaHandler(eventRepository));
            handlerHelper.AddFullyConstrainedCommand(new CreateProgrammaHandler(eventRepository));

            #endregion

            handlerHelper.AddFullyConstrainedCommand( new CreatePlanFromPromotedScenarioHandler(eventRepository));

            
        }

        public override void Subscribe(IBus bus)
        {
            const string subscriptionId = "Super_Programmazione_Ports_";

            var portHelper = new PortHandlerHelper();
            
            portHelper.Add(subscriptionId, _ports, new ScenarioPromotedToPlanHandler());

            portHelper.Add(subscriptionId, _ports, new ScenarioCreatedHandler());
            portHelper.Add(subscriptionId, _ports, new SchedulazioneRotAddedToScenarioHandler());
            portHelper.Add(subscriptionId, _ports, new SchedulazioneRotManAddedToScenarioHandler());
            portHelper.Add(subscriptionId, _ports, new SchedulazioneAmbAddedToScenarioHandler());

            portHelper.Add(subscriptionId, _ports, new SchedulazioneRotAddedToPlanHandler());
            portHelper.Add(subscriptionId, _ports, new SchedulazioneRotManAddedToPlanHandler());
            portHelper.Add(subscriptionId, _ports, new SchedulazioneAmbAddedToPlanHandler());

        }

    }

}
