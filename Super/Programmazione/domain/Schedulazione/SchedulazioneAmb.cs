using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Programma;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain.Schedulazione
{
    public class SchedulazioneAmb : AggregateBase
    {
        public SchedulazioneAmb()
        {
            
        }

        public SchedulazioneAmb(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {

            var evt = BuildEvt.SchedulazioneAmbCreated
                .ForAppaltatore(idAppaltatore)
                .ForProgramma(idProgramma)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .ForQuantity(quantity)
                .ForDescription(description)
                .WithNote(note);
                
            RaiseEvent(idSchedulazione, evt);

            
        }

        public void Apply(SchedulazioneAmbAddedToProgramma evt)
        {
            Id = evt.Id;
        }

    }
}
