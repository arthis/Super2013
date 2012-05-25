using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{

    public class UpdateAreaIntervento : CommandBase
    {
        
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }

        public override string ToDescription()
        {
            return string.Format("Aggiorniamo il Area Intervento '{0}')", Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (UpdateAreaIntervento)obj;

            return base.Equals(obj)
             && base.Equals(other) && other.Start.Equals(Start) && other.End.Equals(End) && Equals(other.Description, Description);
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
                result = (result*397) ^ Start.GetHashCode();
                result = (result*397) ^ (End.HasValue ? End.Value.GetHashCode() : 0);
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }

        public static bool operator ==(UpdateAreaIntervento left, UpdateAreaIntervento right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UpdateAreaIntervento left, UpdateAreaIntervento right)
        {
            return !Equals(left, right);
        }
    }
}
