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
    public class CommandHandlerService<TSession> : CommandHandlerServiceBase<TSession> where TSession : ISession
    {

        public override void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
        {
            var handlerHelper = new CommandHandlerHelper<TSession>(commandRepository, sessionFactory, _handlers);


            handlerHelper.Add( new CancelScenarioHandler<TSession>(eventRepository, sessionFactory));
            handlerHelper.Add( new ChangeDescriptionScenarioHandler(eventRepository));
            handlerHelper.Add( new CreateScenarioHandler<TSession>(eventRepository, sessionFactory));
            handlerHelper.Add( new PromoteScenarioToPlanHandler<TSession>(eventRepository, sessionFactory));

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
