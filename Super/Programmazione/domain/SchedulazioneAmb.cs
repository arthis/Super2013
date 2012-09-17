using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using CommonDomain.Core.Super.Messaging.Builders;
using Super.Programmazione.Events;
using Super.Programmazione.Events.Scenario;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Domain
{
    public class SchedulazioneAmb : AggregateBase
    {
        public SchedulazioneAmb()
        {
            
        }

        public void AddFromScenario( Guid idScenario, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idSchedulazione, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {

            var periodBuilderMsg = new MsgPeriodBuilder();
            period.BuildValue(periodBuilderMsg);

            var workPeriodBuilderMsg = new MsgWorkPeriodBuilder();
            workPeriod.BuildValue((workPeriodBuilderMsg));

            
            var evt = BuildEvt.SchedulazioneAmbAddedToScenario
                .ForAppaltatore(idAppaltatore)
                .ForCategoriaCommerciale(idCategoriaCommerciale)
                .ForCommittente(idCommittente)
                .ForDescription(description)
                .ForDirezioneRegionale(idDirezioneRegionale)
                .ForImpianto(idImpianto)
                .ForLotto(idLotto)
                .ForPeriod(periodBuilderMsg.Build())
                .ForPeriodoProgrammazione(idPeriodoProgrammazione)
                .ForQuantity(quantity)
                .ForScenario(idScenario)
                .ForWorkPeriod(workPeriodBuilderMsg.Build())
                .OfTipoIntervento(idTipoIntervento)
                .WithNote(note);

            RaiseEvent(idSchedulazione, evt);
        }

        public void Apply(SchedulazioneAmbAddedToScenario evt)
        {
            Id = evt.Id;
        }
    }
}
