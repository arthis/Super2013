using System;

namespace CommonDomain.Core.Super.ValueObjects
{
    public abstract class OggettoIntervento
    {
        public string Descrizione { get; set; }
        public int Quantita { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (OggettoIntervento)) return false;
            return Equals((OggettoIntervento) obj);
        }

        public bool Equals(OggettoIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Descrizione, Descrizione) && other.Quantita == Quantita;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Descrizione != null ? Descrizione.GetHashCode() : 0)*397) ^ Quantita;
            }
        }
    }

    public class OggettoRot : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRot { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals((OggettoRot)obj);
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
                return (base.GetHashCode()*397) ^ IdTipoOggettoInterventoRot.GetHashCode();
            }
        }
    }

    public class OggettoRotMan : OggettoIntervento
    {
        public Guid IdTipoOggettoInterventoRotMan { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals((OggettoRotMan)obj);
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
                return (base.GetHashCode()*397) ^ IdTipoOggettoInterventoRotMan.GetHashCode();
            }
        }
    }

}
