using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class CancelScenario : CommandBase
    {
        
        public CancelScenario()
        {
            
        }

        public CancelScenario(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Cancellare un scenario {0}", Id);
        }

        public bool Equals(CancelScenario other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CancelScenario);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
