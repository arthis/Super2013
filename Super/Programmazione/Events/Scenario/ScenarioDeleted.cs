using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class ScenarioDeleted : Message , IEvent
    {
        
        public ScenarioDeleted()
        {
            
        }

        public ScenarioDeleted(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
            
        }

        public override string ToDescription()
        {
            return string.Format("Scenario {0} è stato cancellato", Id);
        }

        public bool Equals(ScenarioDeleted other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ScenarioDeleted);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
