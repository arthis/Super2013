using System;

namespace CommonDomain.Core.Super.Messaging.ValueObjects
{
    [Serializable]
    public abstract class OggettoIntervento
    {
        protected readonly string _description;
        protected readonly int _quantity;

        public string Description
        {
            get { return _description;  }
        }
        public int Quantity
        {
            get { return _quantity; }
        }

        public OggettoIntervento(string description, int quantity)
        {
            _description = description;
            _quantity = quantity;
        }

        public bool Equals(OggettoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._description, _description) && other._quantity == _quantity;
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
                return ((_description != null ? _description.GetHashCode() : 0)*397) ^ _quantity;
            }
        }
    }

    [Serializable]
    public class OggettoRot : OggettoIntervento
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.OggettoRot,
        //the event representation of a value object

        private readonly Guid _idTipoOggettoInterventoRot;

        public Guid IdTipoOggettoInterventoRot
        {
            get { return _idTipoOggettoInterventoRot; }
        }

        public OggettoRot(string description, int quantity, Guid idTipoOggettoInterventoRot)
            : base(description,quantity)
        {
            _idTipoOggettoInterventoRot = idTipoOggettoInterventoRot;
        }

        public bool Equals(OggettoRot other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idTipoOggettoInterventoRot.Equals(_idTipoOggettoInterventoRot);
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
                return (base.GetHashCode()*397) ^ _idTipoOggettoInterventoRot.GetHashCode();
            }
        }
    }

    [Serializable]
    public class OggettoRotMan : OggettoIntervento
    {
        //i.e. CommonDomain.Core.Super.Domain.ValueObjects.OggettoRotMan,
        //the event representation of a value object

        private Guid _idTipoOggettoInterventoRotMan;

        public Guid IdTipoOggettoInterventoRotMan
        {
            get { return _idTipoOggettoInterventoRotMan; }
        }

        public OggettoRotMan(string description, int quantity, Guid idTipoOggettoInterventoRotMan)
            : base(description,quantity)
        {
            _idTipoOggettoInterventoRotMan = idTipoOggettoInterventoRotMan;
        }

        public bool Equals(OggettoRotMan other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idTipoOggettoInterventoRotMan.Equals(_idTipoOggettoInterventoRotMan);
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
                return (base.GetHashCode()*397) ^ _idTipoOggettoInterventoRotMan.GetHashCode();
            }
        }
    }

}
