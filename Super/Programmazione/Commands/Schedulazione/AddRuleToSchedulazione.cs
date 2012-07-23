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
        public int[] WeekDays { get; set; }
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
            Interval intervall,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId,version)
        {
            Contract.Requires<ArgumentNullException>(intervall!=null);
            Contract.Requires<ArgumentNullException>(weekDays != null);

            Interval = intervall;
            WeekDays = weekDays;
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
            Interval intervall,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence,
            Treno trenoArrivo,
            WorkPeriod workPeriod)
            : base(id, idCommitId, version,intervall, weekDays,weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
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
            Interval intervall,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, intervall, weekDays, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
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
            Interval intervall,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, intervall, weekDays, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere una regola alla schedulazione ambiente {0} ", Id);
        }
    }
}
