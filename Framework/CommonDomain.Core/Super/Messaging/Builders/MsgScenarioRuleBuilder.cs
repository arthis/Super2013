using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace CommonDomain.Core.Super.Messaging.Builders
{
    public class MsgRuleBuilder
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

        public MsgRuleBuilder ForInterval(Interval interval)
        {
            _interval = interval;
            return this;
        }

        public MsgRuleBuilder ForMonday(bool monday)
        {
            _monday = monday;
            return this;
        }

        public MsgRuleBuilder ForTuesday(bool tuesday)
        {
            _tuesday = tuesday;
            return this;
        }

        public MsgRuleBuilder ForWedneday(bool wedneday)
        {
            _wednesday = wedneday;
            return this;
        }

        public MsgRuleBuilder ForThursday(bool thursday)
        {
            _thursday = thursday;
            return this;
        }

        public MsgRuleBuilder ForFriday(bool friday)
        {
            _friday = friday;
            return this;
        }

        public MsgRuleBuilder ForSaturday(bool saturday)
        {
            _saturday = saturday;
            return this;
        }

        public MsgRuleBuilder ForSunday(bool sunday)
        {
            _sunday = sunday;
            return this;
        }

        public MsgRuleBuilder ForWeekEnd(bool weekend)
        {
            _weekEnd = weekend;
            return this;
        }

        public MsgRuleBuilder ForHolyday(bool holyday)
        {
            _holyDay = holyday;
            return this;
        }

        public MsgRuleBuilder ForPreHolyday(bool preholyday)
        {
            _preHolyDay = preholyday;
            return this;
        }

        public MsgRuleBuilder ForPostHolyday(bool postholyday)
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
