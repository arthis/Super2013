using System;
using CommonDomain;
using Super.Contabilita.Events.DirezioneRegionale;

namespace Super.Contabilita.Events.Builders.DirezioneRegionale
{
    public class DirezioneRegionaleDeletedBuilder : IEventBuilder<DirezioneRegionaleDeleted>
    {

        public DirezioneRegionaleDeleted Build(Guid id, long version)
        {
            var evt = new DirezioneRegionaleDeleted(id, Guid.NewGuid() ,version);
            
            return evt;
        }

    }


}