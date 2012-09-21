using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Events
{
    public class InterventoClosed : Message , IEvent
    {
        
        private readonly Guid _idUser;
        private readonly DateTime _closingDate;


        public DateTime ClosingDate
        {
            get { return _closingDate; }
        }
        public Guid IdUser
        {
            get { return _idUser; }
        }

        //for serialization
        public InterventoClosed()
        {
            
        }

        public InterventoClosed(Guid id, Guid commitId, long version, Guid idUser, DateTime closingDate)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser != Guid.Empty);
            Contract.Requires(closingDate > DateTime.MinValue);

            _idUser = idUser;
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
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._closingDate.Equals(_closingDate);
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
                
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _closingDate.GetHashCode();
                return result;
            }
        }
    }
	
}
