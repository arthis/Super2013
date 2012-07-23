using System;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Plan
{
    public class SchedulationCancelledFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }

        public SchedulationCancelledFromPlan()
        {

        }

        public SchedulationCancelledFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Schedulazione {0} é stat cancellata dal piano", Id);
        }


    }
}