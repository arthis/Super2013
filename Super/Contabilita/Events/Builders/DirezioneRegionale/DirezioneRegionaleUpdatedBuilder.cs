using System;
using CommonDomain;
using Super.Contabilita.Events.DirezioneRegionale;

namespace Super.Contabilita.Events.Builders.DirezioneRegionale
{
    public class DirezioneRegionaleUpdatedBuilder : IEventBuilder<DirezioneRegionaleUpdated>
    {
        private string _description;

        public DirezioneRegionaleUpdated Build(Guid id, long version)
        {
            var evt = new DirezioneRegionaleUpdated(id, Guid.NewGuid() ,version,  _description);
            
            return evt;
        }

        public DirezioneRegionaleUpdatedBuilder ForDescription(string description)
        {
            _description = description;
            return this;
        }

    }


}