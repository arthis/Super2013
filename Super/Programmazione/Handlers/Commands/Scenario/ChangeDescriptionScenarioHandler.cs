using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class ChangeDescriptionScenarioHandler : CommandHandler<ChangeDescriptionScenario>
    {
        public ChangeDescriptionScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ChangeDescriptionScenario cmd)
        {
            Contract.Requires(cmd != null);

            var existingScenario = EventRepository.GetById<Domain.Scenario>(cmd.Id);

            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            existingScenario.ChangeDescription(cmd.Description);

            EventRepository.Save(existingScenario, cmd.CommitId);

            return existingScenario.CommandValidationMessages; 
        }
    }
}
