using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;

namespace Super.Controllo.Commands
{

    public class ReopenIntervento : CommandBase
    {
        public Guid IdUtente { get; set; }
        public DateTime ReopeningDate { get; set; }

        public override string ToDescription()
        {
            return string.Format("si apri di nuovo il intervento {0}.", Id);
        }

        public bool Equals(ReopenIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUtente.Equals(IdUtente) && other.ReopeningDate.Equals(ReopeningDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ReopenIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result * 397) ^ ReopeningDate.GetHashCode();
                return result;
            }
        }
    }

    
}
