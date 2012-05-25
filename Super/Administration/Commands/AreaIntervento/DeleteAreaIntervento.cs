using System;
using System.Runtime.Serialization;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.Commands.AreaIntervento
{
    
    public class DeleteAreaIntervento : CommandBase
    {

        public DeleteAreaIntervento()
        {
                
        }
      

         public DeleteAreaIntervento(Guid id)
        {
            this.Id = id;
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il Area Intervento (Id:'{0}')", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (DeleteAreaIntervento)obj;

            return base.Equals(obj)
             && base.Equals(other);
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
            return base.GetHashCode();
        }

        public static bool operator ==(DeleteAreaIntervento left, DeleteAreaIntervento right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DeleteAreaIntervento left, DeleteAreaIntervento right)
        {
            return !Equals(left, right);
        }
    }
}
