using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class AddInterventoRotManToPlanHandler: CommandHandler<AddInterventoRotManToPlan>
    {
        public AddInterventoRotManToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddInterventoRotManToPlan cmd)
        {

            Contract.Requires(cmd != null);

            var plan = EventRepository.GetById<Domain.Programma.Plan>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);
            var existingIntervento = EventRepository.GetById<Domain.Intervento.InterventoRotMan>(cmd.IdIntervento);

            if (plan.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            plan.AddInterventoRotMan(
                programma,
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.IdPeriodoProgrammazione,
                cmd.IdIntervento,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note,
                cmd.Oggetti.ToDomain()
);

            EventRepository.Save(programma, cmd.CommitId);

            return programma.CommandValidationMessages; 

        }
    }
}
