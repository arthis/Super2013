using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Handlers.Commands;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Commands.Programmazione;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgramInterventoAmbHandler : CommandHandler<ProgramInterventoAmb>
    {
        public ProgramInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ProgramInterventoAmb cmd)
        {
            Contract.Requires(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

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
                                , cmd.Quantity
                                , cmd.Description
                                , cmd.IdCommittente
                                , cmd.IdPeriodoProgrammazione
                                , cmd.IdProgramma
                                , cmd.IdLotto);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}