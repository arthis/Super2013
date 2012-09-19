using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private readonly Guid _idGruppoOggettoIntervento;

        public Guid IdGruppoOggettoIntervento
        {
            get { return _idGruppoOggettoIntervento; }
        }
        public Guid IdTipoOggettoInterventoRot { get { return _idTipoOggettoInterventoRot; } }

        public OggettoRot(string description, int quantity, Guid idTipoOggettoInterventoRot, Guid idGruppoOggettoIntervento)
            : base( description, quantity)
        {
            if (!IsValid(description, quantity, idTipoOggettoInterventoRot, idGruppoOggettoIntervento))
                throw new Exception("Oggetto Intervento rotabile not valid");

            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;
        }

        public static bool IsValid(string description, int quantity, Guid idTipoOggettoInterventoRot, Guid idGruppoOggettoIntervento)
        {
            if (idTipoOggettoInterventoRot == Guid.Empty)
                return false;

            if (idGruppoOggettoIntervento == Guid.Empty)
                return false;

            return IsValid(description, quantity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as OggettoRot);
        }

        public bool Equals(OggettoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idTipoOggettoInterventoRot.Equals(_idTipoOggettoInterventoRot) && other._idGruppoOggettoIntervento.Equals(_idGruppoOggettoIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _idTipoOggettoInterventoRot.GetHashCode();
                result = (result*397) ^ _idGruppoOggettoIntervento.GetHashCode();
                return result;
            }
        }



        public void BuildValue(MsgOggettoRotBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.OfQuantity(_quantity).OfType(_idTipoOggettoInterventoRot).ForDescription(_description).ForGruppo(_idGruppoOggettoIntervento);
        }
    }

    public class OggettoRotMan : OggettoIntervento
    {
        private readonly Guid _idTipoOggettoInterventoRotMan;
        private Guid _idGruppoOggettoIntervento;

        public OggettoRotMan(string description, int quantity, Guid idTipoOggettoInterventoRotMan, Guid idGruppoOggettoIntervento)
            : base(description, quantity)
        {
            if (!IsValid(description, quantity, idTipoOggettoInterventoRotMan, idGruppoOggettoIntervento))
                throw new Exception("Oggetto Intervento rotabile not valid");

            _idTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan;
            _idGruppoOggettoIntervento = idGruppoOggettoIntervento;

            
        }

        public Guid IdGruppoOggettoIntervento
        {
            get { return _idGruppoOggettoIntervento; }
        }

        public Guid IdTipoOggettoInterventoRotMan
        {
            get { return _idTipoOggettoInterventoRotMan; }
        }

        public static bool IsValid(string description, int quantity, Guid idTipoOggettoInterventoRotMan, Guid idGruppoOggettoIntervento)
        {
            if (idTipoOggettoInterventoRotMan == Guid.Empty)
                return false;

            if (idGruppoOggettoIntervento == Guid.Empty)
                return false;

            return IsValid(description, quantity);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as OggettoRotMan);
        }

        public bool Equals(OggettoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idTipoOggettoInterventoRotMan.Equals(_idTipoOggettoInterventoRotMan) && other._idGruppoOggettoIntervento.Equals(_idGruppoOggettoIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _idTipoOggettoInterventoRotMan.GetHashCode();
                result = (result*397) ^ _idGruppoOggettoIntervento.GetHashCode();
                return result;
            }
        }

        public void BuildValue(MsgOggettoRotManBuilder builder)
        {
            Contract.Requires(builder != null);

            builder.OfQuantity(_quantity)
                .OfType(_idTipoOggettoInterventoRotMan)
                .ForDescription(_description)
                .ForGruppo(_idGruppoOggettoIntervento);
        }
    }

    public static  class OgettoInterventionExtension
    {
        public static IEnumerable<Messaging.ValueObjects.OggettoRot> ToMessage(this IEnumerable<OggettoRot> value )
        {
            var builder = new MsgOggettoRotBuilder();
            foreach (var oggettoRot in value)
            {
                oggettoRot.BuildValue(builder);
                yield return builder.Build();
            }
        }

        public static IEnumerable<OggettoRot> ToDomain(this IEnumerable<Messaging.ValueObjects.OggettoRot> value)
        {
            var builder = new CommonDomain.Core.Super.Domain.Builders.OggettoRotBuilder();
            foreach (var oggettoRot in value)
            {
                yield return builder.ForDescription(oggettoRot.Description)
                .OfQuantity(oggettoRot.Quantity)
                .OfType(oggettoRot.IdTipoOggettoInterventoRot)
                .ForGruppo(oggettoRot.IdGruppoOggettoIntervento)
                .Build();
            }
        }

        public static IEnumerable<Messaging.ValueObjects.OggettoRotMan> ToMessage(this IEnumerable<OggettoRotMan> value)
        {
            var builder = new MsgOggettoRotManBuilder();
            foreach (var oggettoRotMan in value)
            {
                oggettoRotMan.BuildValue(builder);
                yield return builder.Build();
            }
        }

        public static IEnumerable<OggettoRotMan> ToDomain(this IEnumerable<Messaging.ValueObjects.OggettoRotMan> value)
        {
            var builder = new CommonDomain.Core.Super.Domain.Builders.OggettoRotManBuilder();
            foreach (var oggettoRotMan in value)
            {
                yield return builder.ForDescription(oggettoRotMan.Description)
                .OfQuantity(oggettoRotMan.Quantity)
                .OfType(oggettoRotMan.IdTipoOggettoInterventoRotMan)
                .ForGruppo(oggettoRotMan.IdGruppoOggettoIntervento)
                .Build();
            }
        }


    }

}
