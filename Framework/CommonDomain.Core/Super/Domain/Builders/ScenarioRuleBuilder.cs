using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Domain.ValueObjects;

namespace CommonDomain.Core.Super.Domain.Builders
{
    public class RuleBuilder
    {
        private Interval _interval;
        private bool _monday;
        private bool _tuesday;
        private bool _wednesday;
        private bool _thursday;
        private bool _friday;
        private bool _saturday;
        private bool _sunday;
        private bool _weekEnd;
        private bool _holyDay;
        private bool _preHolyDay;
        private bool _postHolyDay;

        public RuleBuilder ForIntervall(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public RuleBuilder ForMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public RuleBuilder ForTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public RuleBuilder ForWedneday(bool wedneday)
        {
            _wednesday = wedneday;
            return this;
        }

        public RuleBuilder ForThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public RuleBuilder ForFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public RuleBuilder ForSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public RuleBuilder ForSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public RuleBuilder ForWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public RuleBuilder ForHolyday(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public RuleBuilder ForPreHolyday(bool preholyday)
        {
            _preHolyDay = preholyday;
            return this;
        }

        public RuleBuilder ForPostHolyday(bool postholyday)
        {
            _postHolyDay = postholyday;
            return this;
        }



        public Rule Build()
        {
            return new Rule(_interval,
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
