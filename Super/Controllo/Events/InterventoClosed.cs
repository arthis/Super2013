using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoClosed : Message , IEvent
    {
        
        private readonly Guid _idUtente;
        private readonly DateTime _closingDate;


        public DateTime ClosingDate
        {
            get { return _closingDate; }
        }
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        //for serialization
        public InterventoClosed()
        {
            
        }

        public InterventoClosed(Guid id, Guid commitId, long version, Guid idUtente, DateTime closingDate)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(idUtente != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(closingDate > DateTime.MinValue);

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
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._closingDate.Equals(_closingDate);
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
                
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _closingDate.GetHashCode();
                return result;
            }
        }
    }
	
}
