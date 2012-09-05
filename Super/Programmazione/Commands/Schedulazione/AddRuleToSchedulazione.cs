using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Commands.Schedulazione
{
    public abstract class AddRuleToSchedulazione : CommandBase
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
         

        public AddRuleToSchedulazione()
        {
            
        }

        public AddRuleToSchedulazione(Guid id, Guid idCommitId, long version,
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
            : base(id, idCommitId,version)
        {
            Contract.Requires<ArgumentNullException>(interval!=null);

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
            return string.Format("Aggiungere una regola alla schedulazione {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazione other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Interval, Interval) && other.Monday.Equals(Monday) && other.Tuesday.Equals(Tuesday) && other.Wednesday.Equals(Wednesday) && other.Thursday.Equals(Thursday) && other.Friday.Equals(Friday) && other.Saturday.Equals(Saturday) && other.Sunday.Equals(Sunday) && other.WeekEnd.Equals(WeekEnd) && other.HolyDay.Equals(HolyDay) && other.PreHolyDay.Equals(PreHolyDay) && other.PostHolyDay.Equals(PostHolyDay);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazione);
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

    public class AddRuleToSchedulazioneRot : AddRuleToSchedulazione
    {
        public Treno TrenoArrivo { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public AddRuleToSchedulazioneRot()
        {

        }

        public AddRuleToSchedulazioneRot(Guid id, Guid idCommitId, long version,
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
            return string.Format("Aggiungere una regola alla schedulazione rotabile {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.TrenoArrivo, TrenoArrivo) && Equals(other.WorkPeriod, WorkPeriod);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (TrenoArrivo != null ? TrenoArrivo.GetHashCode() : 0);
                result = (result*397) ^ (WorkPeriod != null ? WorkPeriod.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class AddRuleToSchedulazioneRotMan : AddRuleToSchedulazione
    {


        public AddRuleToSchedulazioneRotMan()
        {

        }

        public AddRuleToSchedulazioneRotMan(Guid id, Guid idCommitId, long version,
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
            : base(id, idCommitId, version, interval,  monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione rotabile in manutenzione {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneRotMan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneRotMan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class AddRuleToSchedulazioneAmb : AddRuleToSchedulazione
    {


        public AddRuleToSchedulazioneAmb()
        {

        }

        public AddRuleToSchedulazioneAmb(Guid id, Guid idCommitId, long version,
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
            return string.Format("Aggiungere una regola alla schedulazione ambiente {0} ", Id);
        }

        public bool Equals(AddRuleToSchedulazioneAmb other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AddRuleToSchedulazioneAmb);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
