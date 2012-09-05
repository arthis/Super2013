using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleAddedToSchedulazioneRotBuilder :  ICommandBuilder<RuleAddedToSchedulazioneRot>
    {

        protected Interval _interval;
        bool _monday;
        bool _tuesday;
        bool _wednesday;
        bool _thursday;
        bool _friday;
        bool _saturday;
        bool _sunday;
        protected bool _weekEnd;
        protected bool _holyDay;
        protected bool _preHolyDay;
        protected bool _postHolyDay;
        private Treno _trenoArrivo;
        private WorkPeriod _workPeriod;


        public RuleAddedToSchedulazioneRotBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }


        public RuleAddedToSchedulazioneRotBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public RuleAddedToSchedulazioneRotBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
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
                                                   _interval,
                                                   _monday,
                                                   _tuesday,
                                                   _wednesday,
                                                   _thursday,
                                                   _friday,
                                                   _saturday,
                                                   _sunday,
                                                   _weekEnd,
                                                   _holyDay,
                                                   _preHolyDay,
                                                   _postHolyDay,
                                                   _trenoArrivo,
                                                   _workPeriod);
        }


    }
}