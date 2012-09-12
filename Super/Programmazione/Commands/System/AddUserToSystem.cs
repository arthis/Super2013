using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Programmazione.Commands.System
{
    public class AddUserToSystem : CommandBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddUserToSystem()
        {
            
        }

        public AddUserToSystem(Guid id, Guid idCommitId, long version,  string firstName, string lastName)
            : base(id, idCommitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(firstName));
            Contract.Requires(!string.IsNullOrEmpty(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToDescription()
        {
            return string.Format("Aggiungere un utente al sistema programmazione");
        }

        protected bool Equals(AddUserToSystem other)
        {
            return base.Equals(other) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AddUserToSystem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode*397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

}
