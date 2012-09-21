using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleAddedToSchedulazioneRotBuilder :  IEventBuilder<RuleAddedToSchedulazioneRot>
    {

       
        private Treno _trenoArrivo;
        private WorkPeriod _workPeriod;
        private Rule _rule;


        public RuleAddedToSchedulazioneRotBuilder WithRule(Rule rule)
        {
            _rule = rule;
            return this;
        }


        public RuleAddedToSchedulazioneRotBuilder WithTrenoArrivo(Treno trenoArrivo)
        {
            if (trenoArrivo == null) throw new ArgumentNullException("trenoArrivo");

            _trenoArrivo = trenoArrivo;

            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithWorkPeriod(WorkPeriod workPeriod)
        {
            if (workPeriod == null) throw new ArgumentNullException("workPeriod");

            _workPeriod = workPeriod;

            return this;
        }

        public RuleAddedToSchedulazioneRot Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleAddedToSchedulazioneRot Build(Guid id, Guid commitId, long version)
        {
            return new RuleAddedToSchedulazioneRot(id,
                                                   commitId,
                                                   version,
                                                   _rule,
                                                   _trenoArrivo,
                                                   _workPeriod);
        }


    }
}