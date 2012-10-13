using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class AddRuleToSchedulazioneRotManBuilder :  ICommandBuilder<AddRuleToSchedulazioneRotMan>
    {
        private Rule _rule;

        public AddRuleToSchedulazioneRotManBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }


        public AddRuleToSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneRotMan(id, commitId, version, _rule);
        }
    }
}