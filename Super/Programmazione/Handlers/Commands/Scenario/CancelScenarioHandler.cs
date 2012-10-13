using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class CancelScenarioHandler<TSession>: CommandHandler<CancelScenario> where TSession:ISession
    {
        private readonly ISessionFactory<TSession> _sessionFactory;

        public CancelScenarioHandler(IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
            : base(eventRepository)
        {
            _sessionFactory = sessionFactory;
        }

        public override CommandValidation Execute(CancelScenario cmd)
        {
            Contract.Requires(cmd != null);

            var session = _sessionFactory.CreateSession(cmd);

            var existingScenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);

            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingScenario.Cancel(session.UserId);

            EventRepository.Save(existingScenario, cmd.CommitId);

            return existingScenario.CommandValidationMessages; 
        }
    }
}
