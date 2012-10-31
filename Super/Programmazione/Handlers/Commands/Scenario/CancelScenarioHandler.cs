using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Controllo.Domain;
using Super.Programmazione.Commands.Scenario;

namespace Super.Programmazione.Handlers.Commands.Scenario
{
    public class CancelScenarioHandler: CommandHandler<CancelScenario> 
    {

        public CancelScenarioHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CancelScenario cmd)
        {
            Contract.Requires(cmd != null);


            var existingScenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.Id);


            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var user = EventRepository.GetById<Domain.User>(cmd.UserId);

            if (user.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            user.CancelScenario(existingScenario);

            EventRepository.Save(existingScenario, cmd.CommitId);

            return existingScenario.CommandValidationMessages; 
        }
    }
}
