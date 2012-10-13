using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain.Schedulazione
{
    public class SchedulazioneRotMan : AggregateBase
    {
        public SchedulazioneRotMan()
        {
            
        }

        public SchedulazioneRotMan(Guid idProgramma, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente,  Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione,  Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note, IEnumerable<OggettoRotMan> oggetti )
        {
            var evt = BuildEvt.SchedulazioneRotManCreated
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForProgramma(idProgramma)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(idSchedulazione,evt);
        }

        public void Apply(SchedulazioneRotManCreated evt)
        {
            Id = evt.Id;
        }

    }
}
