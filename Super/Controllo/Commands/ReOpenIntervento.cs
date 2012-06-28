using System;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class ReopenIntervento : Message
    {   
        private readonly Guid _idUtente;
        private readonly DateTime _reopeningDate;

        //for serialization
        public ReopenIntervento()
        {
            
        }

        public ReopenIntervento(Guid id, Guid idUtente, DateTime reopeningDate)
        {
            Id = id;
            _idUtente = idUtente;
            _reopeningDate = reopeningDate;
        }

        public DateTime ReopeningDate
        {
            get { return _reopeningDate; }
        }

        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        public override string ToDescription()
        {
            return string.Format("si apri di nuovo il intervento {0}.", Id);
        }

        public bool Equals(ReopenIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._reopeningDate.Equals(_reopeningDate);
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
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _reopeningDate.GetHashCode();
                return result;
            }
        }
    }

    
}
