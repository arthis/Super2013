using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Schedulazione
{
    public abstract class RuleAddedToSchedulazione : Message, IEvent
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


        public RuleAddedToSchedulazione()
        {

        }

        public RuleAddedToSchedulazione(Guid id, Guid idCommitId, long version,
                                        Interval interval,
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
            : base(id, idCommitId, version)
        {
            Contract.Requires(interval != null);

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

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla schedulazione {0} ", Id);
        }

        public bool Equals(RuleAddedToSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && other.Monday.Equals(Monday) && other.Tuesday.Equals(Tuesday) && other.Wednesday.Equals(Wednesday) && other.Thursday.Equals(Thursday) && other.Friday.Equals(Friday) && other.Saturday.Equals(Saturday) && other.Sunday.Equals(Sunday) && other.WeekEnd.Equals(WeekEnd) && other.HolyDay.Equals(HolyDay) && other.PreHolyDay.Equals(PreHolyDay) && other.PostHolyDay.Equals(PostHolyDay);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazione);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Interval != null ? Interval.GetHashCode() : 0);
                result = (result*397) ^ Monday.GetHashCode();
                result = (result*397) ^ Tuesday.GetHashCode();
                result = (result*397) ^ Wednesday.GetHashCode();
                result = (result*397) ^ Thursday.GetHashCode();
                result = (result*397) ^ Friday.GetHashCode();
                result = (result*397) ^ Saturday.GetHashCode();
                result = (result*397) ^ Sunday.GetHashCode();
                result = (result*397) ^ WeekEnd.GetHashCode();
                result = (result*397) ^ HolyDay.GetHashCode();
                result = (result*397) ^ PreHolyDay.GetHashCode();
                result = (result*397) ^ PostHolyDay.GetHashCode();
                return result;
            }
        }
    }


    public class RuleAddedToSchedulazioneRot : RuleAddedToSchedulazione
    {
        public Treno TrenoArrivo { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public RuleAddedToSchedulazioneRot()
        {

        }

        public bool Equals(RuleAddedToSchedulazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }

        public RuleAddedToSchedulazioneRot(Guid id, Guid idCommitId, long version,
            Interval interval,
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
            bool postHolyDay,
            Treno trenoArrivo,
            WorkPeriod workPeriod)
            : base(id, idCommitId, version, interval, monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay)
        {
            TrenoArrivo = trenoArrivo;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla schedulazione rotabile {0} ", Id);
        }


    }

    public class RuleAddedToSchedulazioneRotMan : RuleAddedToSchedulazione
    {


        public RuleAddedToSchedulazioneRotMan()
        {

        }

        public RuleAddedToSchedulazioneRotMan(Guid id, Guid idCommitId, long version,
            Interval interval,
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
            : base(id, idCommitId, version, interval, monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione rotabile in manutenzione {0} ", Id);
        }

        public bool Equals(RuleAddedToSchedulazioneRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class RuleAddedToSchedulazioneAmb : RuleAddedToSchedulazione
    {


        public RuleAddedToSchedulazioneAmb()
        {

        }

        public RuleAddedToSchedulazioneAmb(Guid id, Guid idCommitId, long version,
            Interval interval,
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
            : base(id, idCommitId, version, interval, monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione ambiente {0} ", Id);
        }

        public bool Equals(RuleAddedToSchedulazioneAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as RuleAddedToSchedulazioneAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}