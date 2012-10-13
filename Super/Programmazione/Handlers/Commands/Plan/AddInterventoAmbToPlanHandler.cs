using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class AddInterventoAmbToPlanHandler: CommandHandler<AddInterventoAmbToPlan>
    {
        public AddInterventoAmbToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddInterventoAmbToPlan cmd)
        {

            Contract.Requires(cmd != null);

            var plan = EventRepository.GetById<Domain.Programma.Plan>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);
            var existingIntervento = EventRepository.GetById<Domain.Intervento.InterventoAmb>(cmd.IdIntervento);

            if (plan.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            plan.AddInterventoAmb(
                programma,
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.Description,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.IdPeriodoProgrammazione,
                cmd.Quantity,
                cmd.IdIntervento,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note);

            EventRepository.Save(programma, cmd.CommitId);

            return programma.CommandValidationMessages; 

        }
    }
}
