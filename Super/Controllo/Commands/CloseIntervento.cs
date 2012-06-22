using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class CloseIntervento : CommandBase
    {
        private readonly Guid _idUtente;
        private readonly DateTime _closingDate;

        public CloseIntervento(Guid id, Guid idUtente, DateTime closingDate)
        {
            Id = id;
            _idUtente = idUtente;
            _closingDate = closingDate;
        }

        public DateTime ClosingDate
        {
            get { return _closingDate; }
        }

        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        public override string ToDescription()
        {
            return string.Format("si chiude il intervento {0}.", Id);
        }

        public bool Equals(CloseIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._closingDate.Equals(_closingDate);
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
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _closingDate.GetHashCode();
                return result;
            }
        }
    }

    
}
