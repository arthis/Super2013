using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.GruppoOggettoIntervento
{

    public class GruppoOggettoInterventoUpdated : Message, IEvent
    {

        public string Description { get; set; }


        public GruppoOggettoInterventoUpdated()
        {}

        public GruppoOggettoInterventoUpdated(Guid id, Guid commitId, long version, string description)
            :base (id,commitId,version)
        {
            
            Contract.Requires(!string.IsNullOrEmpty(description));

            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("Il gruppo oggetto intervento '{0}' é stato aggiornato", Description);
        }

        public bool Equals(GruppoOggettoInterventoUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GruppoOggettoInterventoUpdated);
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
