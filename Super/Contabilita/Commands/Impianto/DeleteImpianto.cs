using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;

namespace Super.Contabilita.Commands.Impianto
{
    
    public class DeleteImpianto : CommandBase
    {
        public long Version { get;  set; }

        public DeleteImpianto()
        {
                
        }
      

         public DeleteImpianto(Guid id, Guid commitId, long version)
            : base(id, commitId, version)
        {
        }


        public override string ToDescription()
        {
            return string.Format("Cancelliamo il impianto (Id:'{0}')", Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (DeleteImpianto)obj;

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

        public static bool operator ==(DeleteImpianto left, DeleteImpianto right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DeleteImpianto left, DeleteImpianto right)
        {
            return !Equals(left, right);
        }
    }
}
