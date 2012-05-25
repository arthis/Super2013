using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Appaltatore.Events.Programmazione
{
    public abstract class InterventoProgrammato : Message, IEvent, IEquatable<InterventoProgrammato>
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(InterventoProgrammato other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdAreaIntervento.Equals(IdAreaIntervento) && other.Start.Equals(Start) && other.End.Equals(End);
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
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdAreaIntervento.GetHashCode();
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ End.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(InterventoProgrammato left, InterventoProgrammato right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InterventoProgrammato left, InterventoProgrammato right)
        {
            return !Equals(left, right);
        }
    }

    public class InterventoRotSchedulato : InterventoProgrammato
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile '{0}' é stato programmato.", Id);
        }
    }

    public class InterventoRotManSchedulato : InterventoProgrammato
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento rotabile in manutenzione '{0}' é stato programmato.", Id);
        }
    }

    public class InterventoAmbSchedulato : InterventoProgrammato
    {
        public override string ToDescription()
        {
            return string.Format("Il intervento ambiente '{0}' é stato programmato.", Id);
        }
    }
}