using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Messaging;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public class Rule
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

        public Rule(Interval interval,
            bool monday,
            bool tuesday,
            bool wednesday,
            bool thursday,
            bool friday,
            bool saturday,
            bool sunday,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay)
        {
            if (!IsValid(saturday,sunday,weekEnd))
                throw new Exception("Scenario rule not valid");

            _interval = interval;
            _monday = monday;
            _tuesday = tuesday;
            _wednesday = wednesday;
            _thursday = thursday;
            _friday = friday;
            _saturday = saturday;
            _sunday = sunday;
            _weekEnd = weekEnd;
            _holyDay = holyDay;
            _preHolyDay = preHolyDay;
            _postHolyDay = postHolyDay;
        }

        public static bool IsValid(  bool saturday,
            bool sunday,
            bool weekEnd)
        {
            if((saturday&&sunday) != weekEnd)
                return false;

            return true;
        }


        public void BuildValue(MsgRuleBuilder builder)
        {
            builder
                .ForInterval(_interval.ToMessage())
                .ForMonday(_monday)
                .ForTuesday(_tuesday)
                .ForWedneday(_wednesday)
                .ForThursday(_thursday)
                .ForFriday(_friday)
                .ForSaturday(_saturday)
                .ForSunday(_sunday)
                .ForWeekEnd(_weekEnd)
                .ForHolyday(_holyDay)
                .ForPreHolyday(_preHolyDay)
                .ForPostHolyday(_postHolyDay);
        }
    }

    public static class RuleExtension
    {
        public static Messaging.ValueObjects.Rule ToMessage(this  Rule Rule)
        {
            Contract.Requires(Rule != null);

            var builder = BuildMessagingVO.MsgRule;
            Rule.BuildValue(builder);
            return builder.Build();
        }

        public static Rule ToDomain(this  Messaging.ValueObjects.Rule rule)
        {
            Contract.Requires(rule != null);

            return BuildDomainVO.Rule
                .ForIntervall(rule.Interval.ToDomain())
                .ForMonday(rule.Monday)
                .ForTuesday(rule.Tuesday)
                .ForWedneday(rule.Wednesday)
                .ForThursday(rule.Thursday)
                .ForFriday(rule.Friday)
                .ForSaturday(rule.Saturday)
                .ForSunday(rule.Sunday)
                .ForWeekEnd(rule.WeekEnd)
                .ForHolyday(rule.HolyDay)
                .ForPreHolyday(rule.PreHolyDay)
                .ForPostHolyday(rule.PostHolyDay)
                .Build();
        }
    }
}