using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;


namespace Super.Programmazione.Events.Builders
{
    public abstract class RuleAddedToSchedulazioneBuilder 
    {
         protected Interval _interval;
         protected int[] _weekDays;
         protected bool _weekEnd;
         protected bool _holyDay;
         protected bool _preHolyDay;
         protected bool _postHolyDay;
         protected bool _repetition;
         protected int? _frequence;


         public RuleAddedToSchedulazioneBuilder WithInterval(Interval interval)
         {
             _interval = interval;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithWeekDays(int[] weekDays)
         {
             _weekDays = weekDays;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithHolyDay(bool holyday)
         {
             _holyDay = holyday;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithPreHolyDay(bool preHolyday)
         {
             _preHolyDay = preHolyday;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithPostHolyDay(bool postHolyday)
         {
             _postHolyDay = postHolyday;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithRepetition(bool postHolyday)
         {
             _repetition = postHolyday;
             return this;
         }

         public RuleAddedToSchedulazioneBuilder WithFrequence(int? frequence)
         {
             _frequence = frequence;
             return this;
         }


    }

    public class RuleAddedToSchedulazioneRotBuilder : RuleAddedToSchedulazioneBuilder, ICommandBuilder<RuleAddedToSchedulazioneRot>
    {
        private Treno _trenoArrivo;
        private WorkPeriod _workPeriod;


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
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence,
                                                _trenoArrivo,
                                                _workPeriod);
        }
    }

    public class RuleAddedToSchedulazioneRotManBuilder : RuleAddedToSchedulazioneBuilder, ICommandBuilder<RuleAddedToSchedulazioneRotMan>
    {

        public RuleAddedToSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleAddedToSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new RuleAddedToSchedulazioneRotMan(id,
                                                commitId,
                                                version,
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }

    public class RuleAddedToSchedulazioneAmbBuilder : RuleAddedToSchedulazioneBuilder, ICommandBuilder<RuleAddedToSchedulazioneAmb>
    {

        public RuleAddedToSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public RuleAddedToSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new RuleAddedToSchedulazioneAmb(id,
                                                commitId,
                                                version,
                                                _interval,
                                                _weekDays,
                                                _weekEnd,
                                                _holyDay,
                                                _preHolyDay,
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }
}