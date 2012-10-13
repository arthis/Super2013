using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Plan
{
    public class PlanCreated : Message,IEvent
    {
        
        public PlanCreated()
        {
            
        }

        public PlanCreated(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("piano {0} é stato creato", Id);
        }

        public bool Equals(PlanCreated other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as PlanCreated);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
