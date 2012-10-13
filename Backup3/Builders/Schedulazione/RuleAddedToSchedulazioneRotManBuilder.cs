using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleAddedToSchedulazioneRotManBuilder :  IEventBuilder<RuleAddedToSchedulazioneRotMan>
    {
        private Rule _rule;

        public RuleAddedToSchedulazioneRotManBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }


        public RuleAddedToSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleAddedToSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new RuleAddedToSchedulazioneRotMan(id,
                                                      commitId,
                                                      version,
                                                      _rule);
        }
    }
}