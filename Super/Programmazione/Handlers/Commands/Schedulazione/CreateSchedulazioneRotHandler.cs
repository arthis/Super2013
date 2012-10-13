using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Schedulazione
{
    public class CreateSchedulazioneRotHandler : CommandHandler<CreateSchedulazioneRot>
    {
        public CreateSchedulazioneRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CreateSchedulazioneRot cmd)
        {
            Contract.Requires(cmd != null);

            var existingSchedulazione = EventRepository.GetById<Domain.Schedulazione.SchedulazioneRot>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);

            if (!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();


            var schedulazione = programma.CreateSchedulazioneRot(
                cmd.IdProgramma,
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.Period.ToDomain(),
                cmd.IdPeriodoProgrammazione,
                cmd.Id,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note,
                cmd.Oggetti.ToDomain(),
                cmd.Convoglio,
                cmd.RigaTurnoTreno,
                cmd.TrenoArrivo.ToDomain(),
                cmd.TrenoPartenza.ToDomain(),
                cmd.TurnoTreno);

            EventRepository.Save(schedulazione, cmd.CommitId);

            return schedulazione.CommandValidationMessages; 
        }
    }
}
