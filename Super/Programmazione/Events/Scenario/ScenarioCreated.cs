using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Programmazione.Events.Scenario
{
    public class ScenarioCreated : EventBase
    {
        public Guid IdUser { get; set; }
        public string Description { get; set; }
        public Guid IdProgramma { get; set; }

        public ScenarioCreated()
        {
            
        }

        public ScenarioCreated(Guid id, Guid commitId, long version, Guid idUser, string description, Guid idProgramma)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);
            Contract.Requires(idProgramma!= Guid.Empty);
            Contract.Requires(!string.IsNullOrEmpty(description) );

            IdUser = idUser;
            Description = description;
            IdProgramma = idProgramma;
        }

        public override string ToDescription()
        {
            return string.Format("Scenario {0} é stato creato.", Id);
        }

        protected bool Equals(ScenarioCreated other)
        {
            return base.Equals(other) && IdUser.Equals(other.IdUser) && string.Equals(Description, other.Description) && IdProgramma.Equals(other.IdProgramma);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ScenarioCreated) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ IdUser.GetHashCode();
                hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ IdProgramma.GetHashCode();
                return hashCode;
            }
        }
    }
}
