using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Schedulazione;

namespace Super.Programmazione.Commands.Builders.Schedulazione
{
   

    public class AddRuleToSchedulazioneRotBuilder :  ICommandBuilder<AddRuleToSchedulazioneRot>
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

        public AddRuleToSchedulazioneRotBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneRotBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
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