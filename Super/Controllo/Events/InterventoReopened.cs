using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoReopened : Message , IEvent
    {
        
        private readonly Guid _idUser;
        private readonly DateTime _reopeningDate;


        public DateTime ReopeningDate
        {
            get { return _reopeningDate; }
        }
        public Guid IdUser
        {
            get { return _idUser; }
        }

        //for serialization
        public InterventoReopened()
        {
            
        }

        public InterventoReopened(Guid id, Guid commitId, long version, Guid idUser, DateTime reopeningDate)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser != Guid.Empty);
            Contract.Requires<ArgumentOutOfRangeException>(reopeningDate > DateTime.MinValue);

            _idUser = idUser;
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
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._reopeningDate.Equals(_reopeningDate);
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
                
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _reopeningDate.GetHashCode();
                return result;
            }
        }
    }
	
}
