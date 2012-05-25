using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{
    
    public class CreateAreaIntervento : CommandBase
    {
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreationDate { get; set; }


        public CreateAreaIntervento()
        {
            
        }

        public CreateAreaIntervento(Guid id, DateTime start, DateTime? end, string description, DateTime creationDate)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
            this.Description = description;
            this.CreationDate = creationDate;
        }


        public override string ToDescription()
        {
            return string.Format("Creiamo il area Intervento '{0}'.", Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (CreateAreaIntervento)obj;

            return base.Equals(obj)
             && base.Equals(other) && other.Start.Equals(Start) && other.End.Equals(End) && Equals(other.Description, Description) && other.CreationDate.Equals(CreationDate);
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
                result = (result*397) ^ CreationDate.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(CreateAreaIntervento left, CreateAreaIntervento right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CreateAreaIntervento left, CreateAreaIntervento right)
        {
            return !Equals(left, right);
        }
    }
}
