using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Domain;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class CreateScenarioHandler<TSession> : CommandHandler<CreateScenario> where TSession:ISession
    {
        private readonly ISessionFactory<TSession> _sessionFactory;

        public CreateScenarioHandler(IEventRepository eventRepository, ISessionFactory<TSession> sessionFactory)
            : base(eventRepository)
        {
            Contract.Requires(sessionFactory!=null);
            _sessionFactory = sessionFactory;
        }

        public override CommandValidation Execute(CreateScenario cmd)
        {
            Contract.Requires(cmd != null);

            var session = _sessionFactory.CreateSession(cmd);

            var user = EventRepository.GetById<User>(session.UserId);

            if (user.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var existingScenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);

            if(!existingScenario.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            var scenario = user.CreateScenario(cmd.Id, cmd.IdProgramma, cmd.Description);

            EventRepository.Save(scenario, cmd.CommitId);

            return scenario.CommandValidationMessages; 
        }
    }
}
