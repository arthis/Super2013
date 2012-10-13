using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class PromoteScenarioToPlanHandler<TSession> : CommandHandler<PromoteScenarioToPlan> where TSession:ISession
    {
        private readonly ISessionFactory<TSession> _sessionFactory;

        public PromoteScenarioToPlanHandler(IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
            : base(eventRepository)
        {
            _sessionFactory = sessionFactory;
        }

        public override CommandValidation Execute(PromoteScenarioToPlan cmd)
        {
            Contract.Requires(cmd != null);

            var session = _sessionFactory.CreateSession(cmd);

            var scenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);

            if (scenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            scenario.PromoteToPlan(session.UserId, cmd.PromotionDate, cmd.IdPlan);

            EventRepository.Save(scenario, cmd.CommitId);

            return scenario.CommandValidationMessages; 
        }
    }
}
