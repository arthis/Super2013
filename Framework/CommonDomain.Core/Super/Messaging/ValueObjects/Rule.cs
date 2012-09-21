using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core.Super.Domain;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    public class Rule
    {
        public Interval Interval { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool WeekEnd { get; set; }
        public bool HolyDay { get; set; }
        public bool PreHolyDay { get; set; }
        public bool PostHolyDay { get; set; }

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

            Interval = interval;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;
            WeekEnd = weekEnd;
            HolyDay = holyDay;
            PreHolyDay = preHolyDay;
            PostHolyDay = postHolyDay;
        }

        public static bool IsValid(  bool saturday,
            bool sunday,
            bool weekEnd)
        {
            if((saturday&&sunday) != weekEnd)
                return false;

            return true;
        }

        protected bool Equals(Rule other)
        {
            return Equals(Interval, other.Interval) && Monday.Equals(other.Monday) && Tuesday.Equals(other.Tuesday) && Wednesday.Equals(other.Wednesday) && Thursday.Equals(other.Thursday) && Friday.Equals(other.Friday) && Saturday.Equals(other.Saturday) && Sunday.Equals(other.Sunday) && WeekEnd.Equals(other.WeekEnd) && HolyDay.Equals(other.HolyDay) && PreHolyDay.Equals(other.PreHolyDay) && PostHolyDay.Equals(other.PostHolyDay);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rule) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Interval != null ? Interval.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Monday.GetHashCode();
                hashCode = (hashCode*397) ^ Tuesday.GetHashCode();
                hashCode = (hashCode*397) ^ Wednesday.GetHashCode();
                hashCode = (hashCode*397) ^ Thursday.GetHashCode();
                hashCode = (hashCode*397) ^ Friday.GetHashCode();
                hashCode = (hashCode*397) ^ Saturday.GetHashCode();
                hashCode = (hashCode*397) ^ Sunday.GetHashCode();
                hashCode = (hashCode*397) ^ WeekEnd.GetHashCode();
                hashCode = (hashCode*397) ^ HolyDay.GetHashCode();
                hashCode = (hashCode*397) ^ PreHolyDay.GetHashCode();
                hashCode = (hashCode*397) ^ PostHolyDay.GetHashCode();
                return hashCode;
            }
        }
    }

}