using System;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Plan
{
    public class PlanCancelled : CommandBase
    {
        
        public PlanCancelled()
        {
            
        }

        public PlanCancelled(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("piano {0} é stato cancellato", Id);
        }

        public bool Equals(PlanCancelled other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PlanCancelled);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
