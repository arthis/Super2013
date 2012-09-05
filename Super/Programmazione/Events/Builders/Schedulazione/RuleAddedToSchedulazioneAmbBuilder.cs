using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Events.Schedulazione;

namespace Super.Programmazione.Events.Builders.Schedulazione
{
    public class RuleAddedToSchedulazioneAmbBuilder :  ICommandBuilder<RuleAddedToSchedulazioneAmb>
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

        public RuleAddedToSchedulazioneAmbBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }



        public RuleAddedToSchedulazioneAmbBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public RuleAddedToSchedulazioneAmbBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
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
                                                _postHolyDay);
        }
    }
}