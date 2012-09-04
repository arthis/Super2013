using System;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Schedulazione
{
    public class SchedulazioneCancelledFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }

        public SchedulazioneCancelledFromPlan()
        {

        }

        public SchedulazioneCancelledFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Schedulazione {0} é stat cancellata dal piano", Id);
        }


    }
}