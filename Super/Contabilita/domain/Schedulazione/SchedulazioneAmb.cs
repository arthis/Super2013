using System;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace Super.Contabilita.Domain.Schedulazione
{
    public class SchedulazioneAmb : AggregateBase
    {

        public SchedulazioneAmb(Guid id, Guid idTipoIntervento, Guid idScenario, int quantity,Period period,  WorkPeriod workPeriod)
        {
            
        }
    }
}
