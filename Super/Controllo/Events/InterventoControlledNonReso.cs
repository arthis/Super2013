using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoControlledNonReso : Message, IEvent
    {
        public Guid Id { get; set; }
        public Guid IdUtente { get; set; }
        public Guid ControlDate { get; set; }
        public Guid IdCausale { get; set; }
        public string Note { get; set; }

       
        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato controllato non reso.", Id);
        }

        public bool Equals(InterventoControlledNonReso other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && other.IdUtente.Equals(IdUtente) && other.ControlDate.Equals(ControlDate) && other.IdCausale.Equals(IdCausale) && Equals(other.Note, Note);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoControlledNonReso);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ IdUtente.GetHashCode();
                result = (result*397) ^ ControlDate.GetHashCode();
                result = (result*397) ^ IdCausale.GetHashCode();
                result = (result*397) ^ (Note != null ? Note.GetHashCode() : 0);
                return result;
            }
        }
    }
	
}
