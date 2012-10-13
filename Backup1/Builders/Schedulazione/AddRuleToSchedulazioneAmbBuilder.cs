using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class AddRuleToSchedulazioneAmbBuilder :  ICommandBuilder<AddRuleToSchedulazioneAmb>
    {
        private Rule _rule;


        public AddRuleToSchedulazioneAmbBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }


        public AddRuleToSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneAmb(id, commitId, version, _rule);
        }
    }
}