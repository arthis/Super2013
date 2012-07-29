using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Programmazione.Events.Schedulazione
{
    public abstract class RuleAddedToSchedulazione : Message,IEvent
    {

        public Interval Interval { get; set; }
        public int[] WeekDays { get; set; }
        public bool WeekEnd { get; set; }
        public bool HolyDay { get; set; }
        public bool PreHolyDay { get; set; }
        public bool PostHolyDay { get; set; }
        public bool Repetition { get; set; }
        public int? Frequence { get; set; }    

        public RuleAddedToSchedulazione()
        {
            
        }

        public RuleAddedToSchedulazione(Guid id, Guid idCommitId, long version,
                                        Interval interval,
                                        int[] weekDays,
                                        bool weekEnd,
                                        bool holyDay,
                                        bool preHolyDay,
                                        bool postHolyDay,
                                        bool repetition,
                                        int? frequence)
            : base(id, idCommitId,version)
        {
            Contract.Requires<ArgumentNullException>(interval!=null);
            Contract.Requires<ArgumentNullException>(weekDays != null);

            Interval = interval;
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
            return string.Format("Regola é stata aggiunta alla schedulazione {0} ", Id);
        }
    }


    public class RuleAddedToSchedulazioneRot : RuleAddedToSchedulazione
    {
        public Treno TrenoArrivo { get; set; }
        public WorkPeriod WorkPeriod { get; set; }

        public RuleAddedToSchedulazioneRot()
        {

        }

        public RuleAddedToSchedulazioneRot(Guid id, Guid idCommitId, long version,
            Interval interval,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence,
            Treno trenoArrivo,
            WorkPeriod workPeriod)
            : base(id, idCommitId, version, interval, weekDays, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
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
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, interval, weekDays, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione rotabile in manutenzione {0} ", Id);
        }
    }

    public class RuleAddedToSchedulazioneAmb : RuleAddedToSchedulazione
    {


        public RuleAddedToSchedulazioneAmb()
        {

        }

        public RuleAddedToSchedulazioneAmb(Guid id, Guid idCommitId, long version,
            Interval interval,
            int[] weekDays,
            bool weekEnd,
            bool holyDay,
            bool preHolyDay,
            bool postHolyDay,
            bool repetition,
            int? frequence)
            : base(id, idCommitId, version, interval, weekDays, weekEnd, holyDay, preHolyDay, postHolyDay, repetition, frequence)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Regola é stata aggiunta alla  schedulazione ambiente {0} ", Id);
        }
    }
}