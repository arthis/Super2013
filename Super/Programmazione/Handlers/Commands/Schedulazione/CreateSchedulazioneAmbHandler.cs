using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Handlers.Commands.Schedulazione
{
    public class CreateSchedulazioneAmbHandler : CommandHandler<CreateSchedulazioneAmb>
    {
        public CreateSchedulazioneAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(CreateSchedulazioneAmb cmd)
        {
            Contract.Requires(cmd != null);

            var existingSchedulazione = EventRepository.GetById<Domain.Schedulazione.SchedulazioneAmb>(cmd.Id);
            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.IdProgramma);

            if (!existingSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            var schedulazione = programma.CreateSchedulazioneAmb(
                            cmd.IdProgramma,
                            cmd.IdAppaltatore,
                            cmd.IdCategoriaCommerciale,
                            cmd.IdCommittente,
                            cmd.Description,
                            cmd.IdDirezioneRegionale,
                            cmd.IdImpianto,
                            cmd.IdLotto,
                            cmd.Period.ToDomain(),
                            cmd.IdPeriodoProgrammazione,
                            cmd.Quantity,
                            cmd.Id,
                            cmd.WorkPeriod.ToDomain(),
                            cmd.IdTipoIntervento,
                            cmd.Note);


            EventRepository.Save(schedulazione, cmd.CommitId);

            return schedulazione.CommandValidationMessages;

        }
    }
}
