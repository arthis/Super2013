using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class CreateScenario : CommandBase
    {
        public string Description { get; set; }
        public Guid IdProgramma { get; set; }


        public CreateScenario()
        {
            
        }

        public CreateScenario(Guid id, Guid commitId, long version, string description, Guid idProgramma)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description) );
            Contract.Requires(idProgramma != Guid.Empty);

            Description = description;
            IdProgramma = idProgramma;
        }

        public override string ToDescription()
        {
            return string.Format("Creare un scenario {0}", Id);
        }

        protected bool Equals(CreateScenario other)
        {
            return base.Equals(other) && string.Equals(Description, other.Description) && IdProgramma.Equals(other.IdProgramma);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CreateScenario) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IdProgramma.GetHashCode();
                return hashCode;
            }
        }
    }
}
