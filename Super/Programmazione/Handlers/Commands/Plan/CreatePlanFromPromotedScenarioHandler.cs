using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class CreatePlanFromPromotedScenarioHandler: CommandHandler<CreatePlanFromPromotedScenario>
    {
        

        public CreatePlanFromPromotedScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
            
        }

        public override CommandValidation Execute(CreatePlanFromPromotedScenario cmd)
        {
            Contract.Requires(cmd != null);

            var existingScenario = EventRepository.GetById<Domain.Scenario>(cmd.Id);

            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var plan = existingScenario.CreatePlan(cmd.Id);

            EventRepository.Save(plan, cmd.CommitId);

            return plan.CommandValidationMessages; 
        }
    }
}
