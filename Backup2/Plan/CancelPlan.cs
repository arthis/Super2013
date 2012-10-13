using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public class CancelPlan : CommandBase
    {
        
        public CancelPlan()
        {
            
        }

        public CancelPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Cancellare un piano {0}", Id);
        }

        public bool Equals(CancelPlan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelPlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
