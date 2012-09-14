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

        public SchedulazioneAmb(Guid id, Guid idAppaltatore, Guid idCategoriaCommerciale, Guid idCommittente, string description, Guid idDirezioneRegionale, Guid idImpianto, Guid idLotto, Period period, Guid idPeriodoProgrammazione, int quantity, Guid idScenario, WorkPeriod workPeriod, Guid idTipoIntervento, string note)
        {
            
        }

        public void Apply(SchedulazioneAmbCreated evt)
        {
            Id = evt.Id;
        }
    }
}
