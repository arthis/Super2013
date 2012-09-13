using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class AddRuleToSchedulazioneRotManBuilder :  ICommandBuilder<AddRuleToSchedulazioneRotMan>
    {
        Interval _interval;
        bool _monday;
        bool _tuesday;
        bool _wednesday;
        bool _thursday;
        bool _friday;
        bool _saturday;
        bool _sunday;
        bool _weekEnd;
        bool _holyDay;
        bool _preHolyDay;
        bool _postHolyDay;

        public AddRuleToSchedulazioneRotManBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneRotManBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
            return this;
        }


        public AddRuleToSchedulazioneRotMan Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneRotMan Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneRotMan(id,
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