using System;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Plan
{
    public  class InterventoCancelledFromPlan : CommandBase
    {
        
        public InterventoCancelledFromPlan()
        {
            
        }

        public InterventoCancelledFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("intervento {0} cancellato dal piano.", Id);
        }

        public bool Equals(InterventoCancelledFromPlan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoCancelledFromPlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}