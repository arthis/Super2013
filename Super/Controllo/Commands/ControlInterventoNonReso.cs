using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;

namespace Super.Controllo.Commands
{

    public class ControlInterventoNonReso : CommandBase
    {
        public Guid IdUtente { get; set; }
        public DateTime ControlDate { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }

        public override string ToDescription()
        {
            return string.Format("si controlla non reso il intervento {0}.", Id);
        }

        public bool Equals(ControlInterventoNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.IdUtente.Equals(IdUtente) && other.ControlDate.Equals(ControlDate) && other.IdCausale.Equals(IdCausale) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ControlInterventoNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result*397) ^ ControlDate.GetHashCode();
                result = (result*397) ^ IdCausale.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }

    
}
