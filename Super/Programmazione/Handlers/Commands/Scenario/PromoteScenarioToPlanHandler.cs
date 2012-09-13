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
    public class PromoteScenarioToPlanHandler : CommandHandler<PromoteScenarioToPlan>
    {
        private readonly ISessionFactory _sessionFactory;

        public PromoteScenarioToPlanHandler(IEventRepository eventRepository, ISessionFactory sessionFactory)
            : base(eventRepository)
        {
            _sessionFactory = sessionFactory;
        }

        public override CommandValidation Execute(PromoteScenarioToPlan cmd)
        {
            Contract.Requires(cmd != null);

            var session = _sessionFactory.CreateSession(cmd);

            var existingScenario = EventRepository.GetById<Domain.Scenario>(cmd.Id);

            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            existingScenario.PromoteToPlan(session.UserId, cmd.PromotionDate);

            EventRepository.Save(existingScenario, cmd.CommitId);

            return existingScenario.CommandValidationMessages; 
        }
    }
}
