using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Controllo.Commands;
using Super.Controllo.Commands.Programmazione;
using Super.Controllo.Domain;

namespace Super.Controllo.Handlers
{
    public class ProgramInterventoRotHandler : CommandHandler<ProgramInterventoRot>
    {
        public ProgramInterventoRotHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ProgramInterventoRot cmd)
        {

            Contract.Requires(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoRot>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.Programmare(cmd.Id
                                , cmd.IdImpianto
                                , cmd.IdTipoIntervento
                                , cmd.IdAppaltatore
                                , cmd.IdCategoriaCommerciale
                                , cmd.IdDirezioneRegionale
                                , cmd.WorkPeriod.ToDomain()
                                , cmd.Note
                                , cmd.Oggetti.ToDomain()
                                , cmd.TrenoArrivo.ToDomain()
                                , cmd.TrenoPartenza.ToDomain()
                                , cmd.TurnoTreno
                                , cmd.RigaTurnoTreno
                                , cmd.Convoglio);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}