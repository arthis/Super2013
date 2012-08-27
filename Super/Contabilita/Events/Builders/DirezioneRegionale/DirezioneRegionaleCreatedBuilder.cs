using System;
using CommonDomain;
using Super.Contabilita.Events.DirezioneRegionale;

namespace Super.Contabilita.Events.Builders.DirezioneRegionale
{
    public class DirezioneRegionaleCreatedBuilder : IEventBuilder<DirezioneRegionaleCreated>
    {
        private string _description;


        public DirezioneRegionaleCreated Build(Guid id, long version)
        {
            var evt = new DirezioneRegionaleCreated(id, Guid.NewGuid() ,version,    _description);
            
            return evt;
        }


        public DirezioneRegionaleCreatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }

}