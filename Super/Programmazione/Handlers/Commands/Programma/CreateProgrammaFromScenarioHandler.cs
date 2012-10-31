using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Programma;

namespace Super.Programmazione.Handlers.Commands.Programma
{
    public class CreateProgrammaHandler : CommandHandler<CreateProgramma>
    {

        public CreateProgrammaHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
            
        }

        public override CommandValidation Execute(CreateProgramma cmd)
        {
            Contract.Requires(cmd != null);

            var existingProgramma = EventRepository.GetById<Domain.Programma.Programma>(cmd.Id);
            var existingScenario = EventRepository.GetById<Domain.Programma.Scenario>(cmd.IdScenario);

            if (!existingProgramma.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if (existingScenario.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var programma = existingScenario.CreateProgramma();

            EventRepository.Save(programma, cmd.CommitId);

            return programma.CommandValidationMessages; 
        }
    }
}
