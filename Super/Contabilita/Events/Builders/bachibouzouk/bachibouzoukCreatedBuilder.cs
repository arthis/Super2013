using System;
using CommonDomain;
using Super.Contabilita.Events.bachibouzouk;

namespace Super.Contabilita.Events.Builders.bachibouzouk
{
    public class bachibouzoukCreatedBuilder : IEventBuilder<bachibouzoukCreated>
    {
        public bachibouzoukCreated Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public bachibouzoukCreated Build(Guid id, Guid commitId, long version)
        {
            var cmd = new bachibouzoukCreated(id, commitId, version);
            return cmd;
        }

        
    }
}