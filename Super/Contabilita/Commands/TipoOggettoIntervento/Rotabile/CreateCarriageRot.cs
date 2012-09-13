﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.TipoOggettoIntervento.Rotabile
{
    
    public class CreateCarriageRot : CommandBase
    {
        
        public string Description { get; set; }
        public string Sign { get; set; }
        public bool IsInternational { get; set; }
        public Guid IdGruppoOggettoIntervento { get; set; }


        public CreateCarriageRot()
        {
            
        }

        public CreateCarriageRot(Guid id, Guid commitId, long version, string sign, string description, bool isInternational, Guid idGruppoOggettoIntervento)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sign));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));
            Contract.Requires(idGruppoOggettoIntervento!= Guid.Empty);


            Sign = sign;
            Description = description;
            IsInternational = isInternational;
            IdGruppoOggettoIntervento = idGruppoOggettoIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo una carrozza rotabile '{0}'.", Description);
        }

        public bool Equals(CreateCarriageRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign) && other.IsInternational.Equals(IsInternational);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateCarriageRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                result = (result*397) ^ (Sign != null ? Sign.GetHashCode() : 0);
                result = (result*397) ^ IsInternational.GetHashCode();
                return result;
            }
        }
    }
}