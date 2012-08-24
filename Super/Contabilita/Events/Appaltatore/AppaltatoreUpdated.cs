using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Appaltatore
{
    public class AppaltatoreUpdated : Message, IEvent
    {
        
        public string Description { get; set; }

        public AppaltatoreUpdated()
        {
            
        }

        public AppaltatoreUpdated(Guid id, Guid commitId, long version,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("L'appaltatore é stata aggiornata '{0}'.", Description);
        }

        public bool Equals(AppaltatoreUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as AppaltatoreUpdated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
