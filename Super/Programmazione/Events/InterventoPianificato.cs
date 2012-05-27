using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super;

namespace Super.Programmazione.Events
{
    public abstract class InterventoPianificato : Message,IEvent
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public Guid IdTipoIntervento { get; set; }
        public Guid IdAppaltatore { get; set; }
        public Guid IdCategoriaCommerciale { get; set; }
        public Guid IdDirezioneRegionale { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Note { get; set; }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (InterventoPianificato)obj;

            return base.Equals(obj)
                   && other.Id.Equals(Id) && other.IdAreaIntervento.Equals(IdAreaIntervento) && other.Start.Equals(Start) && other.End.Equals(End);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id.GetHashCode();
                result = (result*397) ^ IdAreaIntervento.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ End.GetHashCode();
                return result;
            }
        }
    }

    public class InterventoRotPianificato : InterventoPianificato, IEquatable<InterventoRotPianificato>
    {
        public OggettoRot[] Oggetti { get; set; }
        public string NumeroTrenoArrivo { get; set; }
        public DateTime DataTrenoArrivo { get; set; }
        public string NumeroTrenoPartenza { get; set; }
        public DateTime DataTrenoPartenza { get; set; }
        public string TurnoTreno { get; set; }
        public string RigaTurnoTreno { get; set; }
        public string Convoglio { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile {0} e stato schedulato.", Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InterventoRotPianificato);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(InterventoRotPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti) && Equals(other.NumeroTrenoArrivo, NumeroTrenoArrivo) && other.DataTrenoArrivo.Equals(DataTrenoArrivo) && Equals(other.NumeroTrenoPartenza, NumeroTrenoPartenza) && other.DataTrenoPartenza.Equals(DataTrenoPartenza) && Equals(other.TurnoTreno, TurnoTreno) && Equals(other.RigaTurnoTreno, RigaTurnoTreno) && Equals(other.Convoglio, Convoglio);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
                result = (result * 397) ^ (NumeroTrenoArrivo != null ? NumeroTrenoArrivo.GetHashCode() : 0);
                result = (result * 397) ^ DataTrenoArrivo.GetHashCode();
                result = (result * 397) ^ (NumeroTrenoPartenza != null ? NumeroTrenoPartenza.GetHashCode() : 0);
                result = (result * 397) ^ DataTrenoPartenza.GetHashCode();
                result = (result * 397) ^ (TurnoTreno != null ? TurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (RigaTurnoTreno != null ? RigaTurnoTreno.GetHashCode() : 0);
                result = (result * 397) ^ (Convoglio != null ? Convoglio.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(InterventoRotPianificato left, InterventoRotPianificato right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InterventoRotPianificato left, InterventoRotPianificato right)
        {
            return !Equals(left, right);
        }
    }

    public class InterventoRotManPianificato : InterventoPianificato, IEquatable<InterventoRotManPianificato>
    {
        public OggettoRotMan[] Oggetti { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento rotabile in manutenzione {0} e stato schedulato.", Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InterventoRotManPianificato);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(InterventoRotManPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.Oggetti, Oggetti);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (Oggetti != null ? Oggetti.GetHashCode() : 0);
            }
        }

        public static bool operator ==(InterventoRotManPianificato left, InterventoRotManPianificato right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InterventoRotManPianificato left, InterventoRotManPianificato right)
        {
            return !Equals(left, right);
        }
    }

    public class InterventoAmbPianificato : InterventoPianificato, IEquatable<InterventoAmbPianificato>
    {
        public int Quantita { get; set; }
        public string Descrizione { get; set; }

        public override string ToDescription()
        {
            return string.Format("Il Intervento ambiente {0} E stato schedulato.", Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InterventoAmbPianificato);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(InterventoAmbPianificato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Quantita == Quantita && Equals(other.Descrizione, Descrizione);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result * 397) ^ Quantita;
                result = (result * 397) ^ (Descrizione != null ? Descrizione.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(InterventoAmbPianificato left, InterventoAmbPianificato right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InterventoAmbPianificato left, InterventoAmbPianificato right)
        {
            return !Equals(left, right);
        }
    }
}