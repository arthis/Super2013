using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class UpdateScenario : CommandBase
    {
        public string Description { get; set; }

        public UpdateScenario()
        {
            
        }

        public UpdateScenario(Guid id, Guid commitId, long version, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description) );

            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiornare il scenario {0}", Id);
        }

        public bool Equals(UpdateScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as UpdateScenario);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ (Description != null ? Description.GetHashCode() : 0);
            }
        }
    }
}
