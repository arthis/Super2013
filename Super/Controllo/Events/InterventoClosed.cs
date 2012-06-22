using System;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoClosed : Message, IEvent
    {
        private readonly Guid _id;
        private readonly Guid _idUtente;
        private readonly DateTime _closingDate;

        public Guid Id
        {
            get { return _id; }
        }
        public DateTime ClosingDate
        {
            get { return _closingDate; }
        }
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        public InterventoClosed(Guid id, Guid idUtente, DateTime closingDate)
        {
            _id = id;
            _idUtente = idUtente;
            _closingDate = closingDate;
        }

        public override string ToDescription()
        {
            return string.Format("Il intervento '{0}' é stato chiuso.", Id);
        }

        public bool Equals(InterventoClosed other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._id.Equals(_id) && other._idUtente.Equals(_idUtente) && other._closingDate.Equals(_closingDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as InterventoClosed);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ _id.GetHashCode();
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _closingDate.GetHashCode();
                return result;
            }
        }
    }
	
}
