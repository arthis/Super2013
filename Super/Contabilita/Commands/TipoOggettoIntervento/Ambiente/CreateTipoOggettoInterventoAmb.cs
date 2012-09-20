﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.Ambiente
{
    
    public class CreateTipoOggettoInterventoAmb : CommandBase
    {
        public string Description { get; set; }
        public Guid IdGruppoOggettoIntervento { get; set; }
        public string Sign { get; set; }
        
        
        public CreateTipoOggettoInterventoAmb()
        {
            
        }

        public CreateTipoOggettoInterventoAmb(Guid id, Guid commitId, long version, string sign, string description, Guid idGruppoOggettoIntervento)
             :base(id,commitId,version)
        {
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(!string.IsNullOrEmpty(sign));
            Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);
            
            Description = description;
            IdGruppoOggettoIntervento = idGruppoOggettoIntervento;
            Sign = sign;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il tipo oggeto intervento ambiente '{0}'.", Description);
        }

        public bool Equals(CreateTipoOggettoInterventoAmb other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && other.IdGruppoOggettoIntervento.Equals(IdGruppoOggettoIntervento) && Equals(other.Sign, Sign);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateTipoOggettoInterventoAmb);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ IdGruppoOggettoIntervento.GetHashCode();
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                return result;
            }
        }
    }
}
