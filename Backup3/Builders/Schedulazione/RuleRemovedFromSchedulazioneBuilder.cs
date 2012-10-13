using System;
using CommonDomain;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleRemovedFromSchedulazioneBuilder : IEventBuilder<RuleRemovedFromSchedulazione>
    {


        public RuleRemovedFromSchedulazione Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleRemovedFromSchedulazione Build(Guid id, Guid idCommitId, long version)
        {
            var cmd = new RuleRemovedFromSchedulazione(id, idCommitId, version);

            return cmd;
        }



    }
}