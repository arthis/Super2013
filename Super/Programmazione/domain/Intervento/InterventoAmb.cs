using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Programma;

namespace Super.Programmazione.Domain.Intervento
{
    public class InterventoAmb : AggregateBase
    {
        public InterventoAmb()
        {

        }

        public InterventoAmb(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Guid idPeriodoProgrammazione, int quantity, Guid idIntervento, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            var evt = BuildEvt.InterventoAmbCreated
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(idProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .ForQuantity(quantity)
                .ForDescription(description)
                .WithNote(note);

            RaiseEvent(idIntervento, evt);


        }

        public void Apply(InterventoAmbAddedToProgramma evt)
        {
            Id = evt.Id;
        }

    }
}
