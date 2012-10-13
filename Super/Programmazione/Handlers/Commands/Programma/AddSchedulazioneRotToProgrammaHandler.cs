using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Programma;

namespace Super.Programmazione.Handlers.Commands.Programma
{
    public class AddSchedulazioneRotToProgrammaHandler : CommandHandler<AddSchedulazioneRotToProgramma>
    {
        
        public AddSchedulazioneRotToProgrammaHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
            
        }

        public override CommandValidation Execute(AddSchedulazioneRotToProgramma cmd)
        {
            Contract.Requires(cmd != null);

            var programma = EventRepository.GetById<Domain.Programma.Programma>(cmd.Id);
            var exisitngSchedulazione = EventRepository.GetById<Domain.Schedulazione.SchedulazioneRot>(cmd.IdSchedulazione);

            if (programma.IsNull())
                throw new AggregateRootInstanceNotFoundException();

            if (!exisitngSchedulazione.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            programma.AddSchedulazioneRot(
                cmd.IdAppaltatore,
                cmd.IdCategoriaCommerciale,
                cmd.IdCommittente,
                cmd.IdDirezioneRegionale,
                cmd.IdImpianto,
                cmd.IdLotto,
                cmd.Period.ToDomain(),
                cmd.IdPeriodoProgrammazione,
                cmd.IdSchedulazione,
                cmd.WorkPeriod.ToDomain(),
                cmd.IdTipoIntervento,
                cmd.Note,
                cmd.Oggetti.ToDomain(),
                cmd.Convoglio,
                cmd.RigaTurnoTreno,
                cmd.TrenoArrivo.ToDomain(),
                cmd.TrenoPartenza.ToDomain(),
                cmd.TurnoTreno);

            EventRepository.Save(programma, cmd.CommitId);

            return programma.CommandValidationMessages;
        }
    }
}
