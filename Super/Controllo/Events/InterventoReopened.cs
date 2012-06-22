using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoReopened : Message, IEvent
    {
        private readonly Guid _id;
        private readonly Guid _idUtente;
        private readonly DateTime _reopeningDate;

        public Guid Id
        {
            get { return _id; }
        }
        public DateTime ReopeningDate
        {
            get { return _reopeningDate; }
        }
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        public InterventoReopened(Guid id, Guid idUtente, DateTime reopeningDate)
        {
            _id = id;
            _idUtente = idUtente;
            _reopeningDate = reopeningDate;
        }


       
        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato aperto di nuovo.", Id);
        }

        public bool Equals(InterventoReopened other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && other._idUtente.Equals(_idUtente) && other._reopeningDate.Equals(_reopeningDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoReopened);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _reopeningDate.GetHashCode();
                return result;
            }
        }
    }
	
}
