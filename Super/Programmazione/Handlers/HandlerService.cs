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

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, IActionFactory actionFactory)
        {
            var handlerHelper = new CommandHandlerHelper(commandRepository, actionFactory, _repositorySecurityUser, Handlers);


            handlerHelper.Add( new CancelScenarioHandler(eventRepository));
            handlerHelper.Add( new ChangeDescriptionScenarioHandler(eventRepository));
            handlerHelper.Add( new CreateScenarioHandler(eventRepository));
            handlerHelper.Add( new PromoteScenarioToPlanHandler(eventRepository));

            #region programma

            handlerHelper.Add( new AddSchedulazioneRotToProgrammaHandler(eventRepository));
            handlerHelper.Add(new CreateProgrammaHandler(eventRepository));

            #endregion

            handlerHelper.Add( new CreatePlanFromPromotedScenarioHandler(eventRepository));

            
        }

        public override void Subscribe(IBus bus)
        {
            string subscriptionId = "Super";

            var portHelper = new PortHandlerHelper();
            
            portHelper.Add(_ports, new ScenarioPromotedToPlanHandler());

            portHelper.Add(_ports, new ScenarioCreatedHandler());
            portHelper.Add(_ports, new SchedulazioneRotAddedToScenarioHandler());
            portHelper.Add(_ports, new SchedulazioneRotManAddedToScenarioHandler());
            portHelper.Add(_ports, new SchedulazioneAmbAddedToScenarioHandler());

            portHelper.Add(_ports, new SchedulazioneRotAddedToPlanHandler());
            portHelper.Add(_ports, new SchedulazioneRotManAddedToPlanHandler());
            portHelper.Add(_ports, new SchedulazioneAmbAddedToPlanHandler());

        }

    }

}
