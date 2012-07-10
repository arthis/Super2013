using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Handlers;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Persistence;
using Super.Appaltatore.Commands;
using Super.Appaltatore.Domain;

namespace Super.Appaltatore.Handlers
{
    public class ProgrammareInterventoAmbHandler : CommandHandler<ProgrammareInterventoAmb>
    {
        public ProgrammareInterventoAmbHandler(IEventRepository eventRepository)
            : base(eventRepository)
        {
        }

        public override CommandValidation Execute(ProgrammareInterventoAmb cmd)
        {
            Contract.Requires<ArgumentNullException>(cmd != null);


            var existingIntervento = EventRepository.GetById<InterventoAmb>(cmd.Id);

            if (!existingIntervento.IsNull())
                throw new AlreadyCreatedAggregateRootException();

            existingIntervento.Programmare(cmd.Id
                                , cmd.IdImpianto
                                , cmd.IdTipoIntervento
                                , cmd.IdAppaltatore
                                , cmd.IdCategoriaCommerciale
                                , cmd.IdDirezioneRegionale
                                , WorkPeriod.FromMessage(cmd.Period)
                                , cmd.Note
                                , cmd.Quantity
                                , cmd.Description);

            EventRepository.Save(existingIntervento, cmd.CommitId);

            return existingIntervento.CommandValidationMessages;
        }
    }
}