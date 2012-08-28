using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.Ambiente
{
    
    public class TipoOggettoInterventoAmbCreated : Message, IEvent
    {
        public string Description { get; set; }
        public string Sign { get; set; }
        
        
        public TipoOggettoInterventoAmbCreated()
        {
            
        }

        public TipoOggettoInterventoAmbCreated(Guid id, Guid commitId, long version, string sign, string description)
             :base(id,commitId,version)
        {
            
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sign));
            
            Description = description;
            Sign = sign;
        }

        public override string ToDescription()
        {
            return string.Format("Il tipo oggeto intervento ambiente é stato creato '{0}'.", Description);
        }

        public bool Equals(TipoOggettoInterventoAmbCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as TipoOggettoInterventoAmbCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                return result;
            }
        }
    }
}
