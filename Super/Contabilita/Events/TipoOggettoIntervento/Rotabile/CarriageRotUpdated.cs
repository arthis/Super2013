﻿using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Contabilita.Events.TipoOggettoIntervento.Rotabile
{

    public class CarriageRotUpdated : EventBase
    {
        public string Description { get; set; }
        public string Sign { get; set; }
        public bool IsInternational { get; set; }
        public Guid IdGruppoOggettoIntervento { get; set; }

        public CarriageRotUpdated()
        {}

        public CarriageRotUpdated(Guid id, Guid commitId, long version, string sign, string description, bool isInternational, Guid idGruppoOggettoIntervento)
            : base(id, commitId, version)
        {
            Contract.Requires(!string.IsNullOrEmpty(sign));
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(idGruppoOggettoIntervento != Guid.Empty);

            Sign = sign;
            Description = description;
            IsInternational = isInternational;
            IdGruppoOggettoIntervento = idGruppoOggettoIntervento;
        }

        public override string ToDescription()
        {
            return string.Format("La carrozza rotabile é stata aggiornata '{0}')", Description);
        }

        public bool Equals(CarriageRotUpdated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Description, Description) && Equals(other.Sign, Sign) && other.IsInternational.Equals(IsInternational);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CarriageRotUpdated);
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
