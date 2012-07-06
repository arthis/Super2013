using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoReopened : Message , IEvent
    {
        
        private readonly Guid _idUtente;
        private readonly DateTime _reopeningDate;


        public DateTime ReopeningDate
        {
            get { return _reopeningDate; }
        }
        public Guid IdUtente
        {
            get { return _idUtente; }
        }

        //for serialization
        public InterventoReopened()
        {
            
        }

        public InterventoReopened(Guid id, Guid commitId, long version, Guid idUtente, DateTime reopeningDate)
            : base(id, commitId, version)
        {
            Contract.Requires<ArgumentNullException>(idUtente != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(reopeningDate > DateTime.MinValue);

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
            return base.Equals(other) && other._idUtente.Equals(_idUtente) && other._reopeningDate.Equals(_reopeningDate);
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
                
                result = (result*397) ^ _idUtente.GetHashCode();
                result = (result*397) ^ _reopeningDate.GetHashCode();
                return result;
            }
        }
    }
	
}
