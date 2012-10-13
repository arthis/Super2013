using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
   

    public class AddRuleToSchedulazioneRotBuilder :  ICommandBuilder<AddRuleToSchedulazioneRot>
    {
        private Rule _rule;
        private Treno _trenoArrivo;
        private WorkPeriod _workPeriod;


        public AddRuleToSchedulazioneRotBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            if (trenoArrivo == null) throw new ArgumentNullException("trenoArrivo");

            _trenoArrivo = trenoArrivo;

            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithWorkPeriod(WorkPeriod workPeriod)
        {
            if (workPeriod == null) throw new ArgumentNullException("workPeriod");

            _workPeriod = workPeriod;

            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }


        public AddRuleToSchedulazioneRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneRot Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneRot(id,
                                                commitId,
                                                version,
                                                _rule,
                                                _trenoArrivo,
                                                _workPeriod);
        }
    }
}