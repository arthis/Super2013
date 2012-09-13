using System;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Plan
{
    public class CreatePlan : CommandBase
    {
        
        public CreatePlan()
        {
            
        }

        public CreatePlan(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Creare un piano {0}", Id);
        }

        public bool Equals(CreatePlan other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreatePlan);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
