using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Intervento;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Domain.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Plan
{
    public class AddInterventoRotToPlanHandler : CommandHandler<AddInterventoRotToPlan>
    {
        public AddInterventoRotToPlanHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(AddInterventoRotToPlan cmd)
        {

            Contract.Requires(cmd != null);

            var plan = EventRepository.GetById<Domain.Programma.Plan>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);
            var existingIntervento = EventRepository.GetById<Domain.Intervento.InterventoRot>(cmd.IdIntervento);

            if (plan.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            plan.AddInterventoRot(
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
                cmd.Convoglio,
                cmd.RigaTurnoTreno,
                cmd.TurnoTreno,
                cmd.TrenoArrivo.ToDomain(),
                cmd.TrenoPartenza.ToDomain(),
                cmd.Oggetti.ToDomain()
);

            EventRepository.Save(programma, cmd.CommitId);

            return programma.CommandValidationMessages; 

        }
    }
}
