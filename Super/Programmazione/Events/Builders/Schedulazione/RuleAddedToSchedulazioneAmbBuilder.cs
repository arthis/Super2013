using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleAddedToSchedulazioneAmbBuilder :  IEventBuilder<RuleAddedToSchedulazioneAmb>
    {
        private Rule _rule;


        public RuleAddedToSchedulazioneAmbBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }



        public RuleAddedToSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleAddedToSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new RuleAddedToSchedulazioneAmb(id,
                                                commitId,
                                                version,
                                                _rule);
        }
    }
}