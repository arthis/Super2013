using System;
using CommonDomain;
using Super.Contabilita.Events.PeriodoProgrammazione;

namespace Super.Contabilita.Events.Builders.PeriodoProgrammazione
{
    public class PeriodoProgrammazioneDeletedBuilder : IEventBuilder<PeriodoProgrammazioneDeleted>
    {

        public PeriodoProgrammazioneDeleted Build(Guid id, long version)
        {
            var evt = new PeriodoProgrammazioneDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}