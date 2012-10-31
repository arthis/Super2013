using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;
using Super.Programmazione.Domain;
using User = Super.Programmazione.Domain.User;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class CreateScenarioHandler : CommandHandler<CreateScenario>
    {

        public CreateScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
            
        }

        public override CommandValidation Execute(CreateScenario cmd)
        {
            Contract.Requires(cmd != null);

            var existingScenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);

            if(!existingScenario.IsNull())
                throw new AlreadyCreatedAggregateRootException();
            
            var user = EventRepository.GetById<User>(cmd.UserId);
            
            var scenario = user.CreateScenario(cmd.Id, cmd.IdProgramma, cmd.Description);

            EventRepository.Save(scenario, cmd.CommitId);

            return scenario.CommandValidationMessages; 
        }
    }
}
