using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.GruppoOggettoIntervento
{
    
    public class GruppoOggettoInterventoCreated : EventBase
    {
        
        public string Description { get;  set; }

        public GruppoOggettoInterventoCreated()
        {
            
        }

        public GruppoOggettoInterventoCreated(Guid id, Guid commitId, long version,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));

            
            this.Description = description;
;
        }

        public override string ToDescription()
        {
            return string.Format("Il gruppo oggetto intervento '{0}' é stato creato.", Description);
        }

        public bool Equals(GruppoOggettoInterventoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GruppoOggettoInterventoCreated);
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
