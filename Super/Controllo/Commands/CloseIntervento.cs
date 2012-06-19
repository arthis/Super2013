using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class CloseIntervento : CommandBase
    {
        public Guid IdUtente { get; set; }
        public DateTime ClosingDate { get; set; }

        public override string ToDescription()
        {
            return string.Format("si chiude il intervento {0}.", Id);
        }

        public bool Equals(CloseIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUtente.Equals(IdUtente) && other.ClosingDate.Equals(ClosingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CloseIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result*397) ^ ClosingDate.GetHashCode();
                return result;
            }
        }
    }

    
}
