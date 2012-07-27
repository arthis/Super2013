using System;
using CommonDomain;
using CommonDomain.Core.Super.Messaging.ValueObjects;
using Super.Programmazione.Commands.Plan;
using Super.Programmazione.Commands.Schedulazione;


namespace Super.Programmazione.Commands.Builders
{
    public abstract class AddRuleToSchedulazioneBuilder 
    {
        


    }

    public class AddRuleToSchedulazioneRotBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneRot>
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
        bool _repetition;
        int? _frequence;


       
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

        public AddRuleToSchedulazioneBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithRepetition(bool postHolyday)
        {
            _repetition = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFrequence(int? frequence)
        {
            _frequence = frequence;
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
                                                _repetition,
                                                _frequence,
                                                _trenoArrivo,
                                                _workPeriod);
        }
    }

    public class AddRuleToSchedulazioneRotManBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneRotMan>
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
        bool _repetition;
        int? _frequence;

        public AddRuleToSchedulazioneBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithRepetition(bool postHolyday)
        {
            _repetition = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFrequence(int? frequence)
        {
            _frequence = frequence;
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
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }

    public class AddRuleToSchedulazioneAmbBuilder : AddRuleToSchedulazioneBuilder, ICommandBuilder<AddRuleToSchedulazioneAmb>
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
        bool _repetition;
        int? _frequence;

        public AddRuleToSchedulazioneBuilder WithInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithWedneday(bool wednesday)
        {
            _wednesday = wednesday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithHolyDay(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPreHolyDay(bool preHolyday)
        {
            _preHolyDay = preHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithPostHolyDay(bool postHolyday)
        {
            _postHolyDay = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithRepetition(bool postHolyday)
        {
            _repetition = postHolyday;
            return this;
        }

        public AddRuleToSchedulazioneBuilder WithFrequence(int? frequence)
        {
            _frequence = frequence;
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
                                                _postHolyDay,
                                                _repetition,
                                                _frequence);
        }
    }
}