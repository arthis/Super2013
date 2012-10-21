using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.DirezioneRegionale
{
    public class DirezioneRegionaleCreated : EventBase
    {
        public string Description { get;  set; }

        //for serialization
        public DirezioneRegionaleCreated()
        {
            
        }

        public DirezioneRegionaleCreated(Guid id, Guid commitId, long version, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));

            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("La direzione regionale é stata creata '{0}'.", Description);
        }

        public bool Equals(DirezioneRegionaleCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  && Equals(other.Description, Description) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as DirezioneRegionaleCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
