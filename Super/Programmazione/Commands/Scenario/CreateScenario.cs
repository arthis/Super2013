using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.Scenario
{
    public class CreateScenario : CommandBase
    {
        public Guid IdUser { get; set; }
        public string Description { get; set; }

        public CreateScenario()
        {
            
        }

        public CreateScenario(Guid id, Guid commitId, long version, Guid idUser, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);
            Contract.Requires(!string.IsNullOrEmpty(description) );

            IdUser = idUser;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Creare un scenario {0}", Id);
        }

        public bool Equals(CreateScenario other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUser.Equals(IdUser) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateScenario);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUser.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
