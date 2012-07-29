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
        public bool Repetition { get; set; }
        public int? Frequence { get; set; }    

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
            bool postHolyDay,
            bool repetition,
            int? frequence)
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
            Repetition = repetition;
            Frequence = frequence;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione {0} ", Id);
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
            bool repetition,
            int? frequence,
            Treno trenoArrivo,
            WorkPeriod workPeriod)
            : base(id, idCommitId, version, interval, monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {
            TrenoArrivo = trenoArrivo;
            WorkPeriod = workPeriod;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione rotabile {0} ", Id);
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
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, interval,  monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione rotabile in manutenzione {0} ", Id);
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
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, interval, monday, tuesday, wednesday, thursday, friday, saturday, sunday, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione ambiente {0} ", Id);
        }
    }
}
