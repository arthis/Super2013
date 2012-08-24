using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.CategoriaCommerciale
{
    public class CategoriaCommercialeCreated : Message, IEvent
    {
        public string Description { get;  set; }

        //for serialization
        public CategoriaCommercialeCreated()
        {
            
        }

        public CategoriaCommercialeCreated(Guid id, Guid commitId, long version, string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));

            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("La categoria commerciale é stata creata '{0}'.", Description);
        }

        public bool Equals(CategoriaCommercialeCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other)  && Equals(other.Description, Description) ;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CategoriaCommercialeCreated);
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
