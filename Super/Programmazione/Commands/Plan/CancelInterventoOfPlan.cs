using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public  class CancelInterventoFromPlan : CommandBase
    {
        
        public CancelInterventoFromPlan()
        {
            
        }

        public CancelInterventoFromPlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Cancellare un intervento {0} del piano.", Id);
        }

        public bool Equals(CancelInterventoFromPlan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelInterventoFromPlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}