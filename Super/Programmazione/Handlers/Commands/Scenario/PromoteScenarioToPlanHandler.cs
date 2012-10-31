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
    public class PromoteScenarioToPlanHandler : CommandHandler<PromoteScenarioToPlan>
    {
        

        public PromoteScenarioToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
            
        }

        public override CommandValidation Execute(PromoteScenarioToPlan cmd)
        {
            Contract.Requires(cmd != null);


            var scenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);

            if (scenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var user = EventRepository.GetById<User>(cmd.UserId);

            if (user.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            user.PromoteToPlan(scenario, cmd.PromotionDate, cmd.IdPlan);

            EventRepository.Save(scenario, cmd.CommitId);

            return scenario.CommandValidationMessages; 
        }
    }
}
