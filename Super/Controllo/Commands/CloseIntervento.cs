using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class CloseIntervento : CommandBase
    {
        private readonly Guid _idUser;
        private readonly DateTime _closingDate;

        //for serialization
        public CloseIntervento()
        {
            
        }

        public CloseIntervento(Guid id, Guid commitId, long version, Guid idUser, DateTime closingDate)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!=Guid.Empty);
            Contract.Requires(closingDate > DateTime.MinValue);

            _idUser = idUser;
            _closingDate = closingDate;
        }

        public DateTime ClosingDate
        {
            get { return _closingDate; }
        }

        public Guid IdUser
        {
            get { return _idUser; }
        }

        public override string ToDescription()
        {
            return string.Format("si chiude il intervento {0}.", Id);
        }

        public bool Equals(CloseIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._closingDate.Equals(_closingDate);
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
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _closingDate.GetHashCode();
                return result;
            }
        }
    }

    
}
