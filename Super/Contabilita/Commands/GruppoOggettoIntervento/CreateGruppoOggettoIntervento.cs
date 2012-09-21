using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.GruppoOggettoIntervento
{
    
    public class CreateGruppoOggettoIntervento : CommandBase
    {
        
        public string Description { get;  set; }

        public CreateGruppoOggettoIntervento()
        {
            
        }

        public CreateGruppoOggettoIntervento(Guid id, Guid commitId, long version,  string description)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));

            
            this.Description = description;
;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il grupp oggetto intervento '{0}'.", Description);
        }

        public bool Equals(CreateGruppoOggettoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateGruppoOggettoIntervento);
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
