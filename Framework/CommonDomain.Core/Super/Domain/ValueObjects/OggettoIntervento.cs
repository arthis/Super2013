using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core.Super.Messaging.Builders;

namespace CommonDomain.Core.Super.Domain.ValueObjects
{
    public abstract class OggettoIntervento
    {
        protected string _description;
        protected int _quantity;

        public string Description { get { return _description; } }
        public int Quantity { get { return _quantity; } }

        public OggettoIntervento(string description, int quantity)
        {
            _description = description;
            _quantity = quantity;
        }


        protected static bool IsValid(string description, int quantity)
        {
            if (quantity <= 0)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(OggettoIntervento)) return false;
            return Equals((OggettoIntervento)obj);
        }

        public bool Equals(OggettoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Description, Description) && other.Quantity == Quantity;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Description != null ? Description.GetHashCode() : 0) * 397) ^ Quantity;
            }
        }
    }

    public class OggettoRot : OggettoIntervento
    {
        private Guid _idTipoOggettoInterventoRot;

        public Guid IdTipoOggettoInterventoRot { get { return _idTipoOggettoInterventoRot; } }

        public OggettoRot(string description, int quantity, Guid idTipoOggettoInterventoRot)
            : base( description, quantity)
        {
            if (!IsValid(description, quantity, idTipoOggettoInterventoRot))
                throw new Exception("Oggetto Intervento rotabile not valid");

            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
        }

        public static bool IsValid(string description, int quantity, Guid idTipoOggettoInterventoRot)
        {
            if (idTipoOggettoInterventoRot == Guid.Empty)
                return false;

            return IsValid(description, quantity);
        }

        public override bool Equals(object obj)
        {
            return Equals((OggettoRot)obj);
        }

        public bool Equals(OggettoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoOggettoInterventoRot.Equals(IdTipoOggettoInterventoRot);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ IdTipoOggettoInterventoRot.GetHashCode();
            }
        }

        public void BuildValue(OggettoRotBuilder builder)
        {
            builder.OfQuantity(_quantity).OfType(_idTipoOggettoInterventoRot).ForDescription(_description);
        }
    }

    public class OggettoRotMan : OggettoIntervento
    {
        private readonly Guid _idTipoOggettoInterventoRotMan;

        public OggettoRotMan(string description, int quantity, Guid idTipoOggettoInterventoRotMan)
            : base(description, quantity)
        {
            _idTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan;
        }

        public Guid IdTipoOggettoInterventoRotMan
        {
            get { return _idTipoOggettoInterventoRotMan; }
        }

        public static bool IsValid(string description, int quantity, Guid IdTipoOggettoInterventoRotMan)
        {
            if (IdTipoOggettoInterventoRotMan == Guid.Empty)
                return false;

            return IsValid(description, quantity);
        }

        public override bool Equals(object obj)
        {
            return Equals((OggettoRotMan)obj);
        }

        public bool Equals(OggettoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdTipoOggettoInterventoRotMan.Equals(IdTipoOggettoInterventoRotMan);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ IdTipoOggettoInterventoRotMan.GetHashCode();
            }
        }

        public void BuildValue(OggettoRotManBuilder builder)
        {
            builder.OfQuantity(_quantity).OfType(_idTipoOggettoInterventoRotMan).ForDescription(_description);
        }
    }

    public static  class OgettoInterventionExtension
    {
        public static IEnumerable<Messaging.ValueObjects.OggettoRot> ToMessage(this IEnumerable<OggettoRot> value )
        {
            var builder = new OggettoRotBuilder();
            foreach (var oggettoRot in value)
            {
                oggettoRot.BuildValue(builder);
                yield return builder.Build();
            }
        }

        public static IEnumerable<OggettoRot> ToValueObject(this IEnumerable<Messaging.ValueObjects.OggettoRot> value)
        {
            foreach (var oggettoRot in value)
            {
                yield return new OggettoRot(oggettoRot.Description, oggettoRot.Quantity, oggettoRot.IdTipoOggettoInterventoRot);
            }
        }

        public static IEnumerable<Messaging.ValueObjects.OggettoRotMan> ToMessage(this IEnumerable<OggettoRotMan> value)
        {
            var builder = new OggettoRotManBuilder();
            foreach (var oggettoRotMan in value)
            {
                oggettoRotMan.BuildValue(builder);
                yield return builder.Build();
            }
        }

        public static IEnumerable<OggettoRotMan> ToValueObject(this IEnumerable<Messaging.ValueObjects.OggettoRotMan> value)
        {
            foreach (var oggettoRotMan in value)
            {
                yield return new OggettoRotMan(oggettoRotMan.Description, oggettoRotMan.Quantity, oggettoRotMan.IdTipoOggettoInterventoRotMan);
            }
        }


    }

}
