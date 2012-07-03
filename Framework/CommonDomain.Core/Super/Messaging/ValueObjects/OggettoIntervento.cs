﻿using System;
using System.Diagnostics.Contracts;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public abstract class OggettoIntervento
    {

        public string Description { get; set; }
        public int Quantity { get; set; }

        public OggettoIntervento()
        {}

        public OggettoIntervento(string description, int quantity)
        {
            Contract.Requires<ArgumentOutOfRangeException>(quantity>0);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(description));

            Description = description;
            Quantity = quantity;
        }


        public bool Equals(OggettoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (OggettoIntervento)) return false;
            return Equals((OggettoIntervento) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Description != null ? Description.GetHashCode() : 0)*397) ^ Quantity;
            }
        }
    }

    [Serializable]
    public class OggettoRot : OggettoIntervento
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.OggettoRot,
        //the event representation of a value object


        public Guid IdTipoOggettoInterventoRot { get; set; }

        public OggettoRot(string description, int quantity, Guid idTipoOggettoInterventoRot)
            : base(description,quantity)
        {
            Contract.Requires<ArgumentNullException>(idTipoOggettoInterventoRot!= Guid.Empty);

            IdTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
        }

        public bool Equals(OggettoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoOggettoInterventoRot.Equals(IdTipoOggettoInterventoRot);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as OggettoRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdTipoOggettoInterventoRot.GetHashCode();
            }
        }
    }

    [Serializable]
    public class OggettoRotMan : OggettoIntervento
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.OggettoRotMan,
        //the event representation of a value object


        public Guid IdTipoOggettoInterventoRotMan { get; set; }

        public OggettoRotMan(string description, int quantity, Guid idTipoOggettoInterventoRotMan)
            : base(description,quantity)
        {
            Contract.Requires<ArgumentNullException>(idTipoOggettoInterventoRotMan != Guid.Empty);

            IdTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan;
        }

        public bool Equals(OggettoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoOggettoInterventoRotMan.Equals(IdTipoOggettoInterventoRotMan);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as OggettoRotMan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ IdTipoOggettoInterventoRotMan.GetHashCode();
            }
        }
    }

}
