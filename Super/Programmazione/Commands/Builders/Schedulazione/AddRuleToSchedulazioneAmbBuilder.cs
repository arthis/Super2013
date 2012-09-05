using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
    public class AddRuleToSchedulazioneAmbBuilder :  ICommandBuilder<AddRuleToSchedulazioneAmb>
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


        public AddRuleToSchedulazioneAmbBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneAmbBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneAmb Build(Guid id, long version)
        {
            return Build(id, Guid.NewGuid(), version);
        }

        public AddRuleToSchedulazioneAmb Build(Guid id, Guid commitId, long version)
        {
            return new AddRuleToSchedulazioneAmb(id,
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