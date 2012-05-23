using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;

namespace Super.Appaltatore.Commands
{
    

    public abstract class ProgrammareIntervento : CommandBase
    {
        public Guid Id { get; set; }
        public Guid IdAreaIntervento { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            var other = (ProgrammareIntervento)obj;

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

    public class ProgrammareInterventoRot : ProgrammareIntervento
    {
        
        public override string ToDescription()
        {
            return string.Format("programmare il intervento rotabile {0}.", Id);
        }

    }

    public class ProgrammareInterventoRotMan : ProgrammareIntervento
    {
        public override string ToDescription()
        {
            return string.Format("programmare il intervento rotabile in manutenzione {0}.", Id);
        }
    }

    public class ProgrammareInterventoAmb : ProgrammareIntervento
    {
        public override string ToDescription()
        {
            return string.Format("programmare il intervento ambiente {0} is Schedulato.", Id);
        }
    }
}
