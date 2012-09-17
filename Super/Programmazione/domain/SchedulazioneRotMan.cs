using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Schedulazione;
using Period = CommonDomain.Core.Super.Domain.ValueObjects.Period;
using WorkPeriod = CommonDomain.Core.Super.Domain.ValueObjects.WorkPeriod;
using Treno = CommonDomain.Core.Super.Domain.ValueObjects.Treno;
using OggettoRotMan = CommonDomain.Core.Super.Domain.ValueObjects.OggettoRotMan;

namespace Super.Programmazione.Domain
{
    public class SchedulazioneRotMan : AggregateBase
    {
        public SchedulazioneRotMan()
        {
            
        }

        public void AddFromScenario(Guid idScenario, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente,  Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note,  IEnumerable<OggettoRotMan> oggetti)
        {

            var evt = BuildEvt.SchedulazioneRotManAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(period.ToMessage())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriod.ToMessage())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note)
                .WithOggetti(oggetti.ToMessage().ToArray());

            RaiseEvent(idSchedulazione, evt);
        }

        public void Apply(SchedulazioneRotManAddedToScenario evt)
        {
            Id = evt.Id;
        }
    }
}
