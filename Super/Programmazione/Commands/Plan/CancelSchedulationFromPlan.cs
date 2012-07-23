using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public class CancelSchedulationFromPlan : CommandBase
    {
        public Guid IdUser { get; set; }

        public CancelSchedulationFromPlan()
        {

        }

        public CancelSchedulationFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal piano ", Id);
        }


    }
}