using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public class CancelSchedulationOfPlan : CommandBase
    {
        public Guid IdUser { get; set; }

        public CancelSchedulationOfPlan()
        {

        }

        public CancelSchedulationOfPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {

        }

        public override string ToDescription()
        {
            return string.Format("Cancellare schedulazione {0} dal scenario ", Id);
        }


    }
}