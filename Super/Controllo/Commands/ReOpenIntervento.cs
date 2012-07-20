using System;
using System.Diagnostics.Contracts;
using System.Linq;
using CommandService;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Controllo.Commands
{

    public class ReopenIntervento : CommandBase
    {   
        private readonly Guid _idUser;
        private readonly DateTime _reopeningDate;

        //for serialization
        public ReopenIntervento()
        {
            
        }

        public ReopenIntervento(Guid id, Guid commitId, long version, Guid idUser, DateTime reopeningDate)
            : base(id, commitId, version)
        {
            Contract.Requires(idUser!= Guid.Empty);
            Contract.Requires(reopeningDate > DateTime.Now);

            _idUser = idUser;
            _reopeningDate = reopeningDate;
        }

        public DateTime ReopeningDate
        {
            get { return _reopeningDate; }
        }

        public Guid IdUser
        {
            get { return _idUser; }
        }

        public override string ToDescription()
        {
            return string.Format("si apri di nuovo il intervento {0}.", Id);
        }

        public bool Equals(ReopenIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other._idUser.Equals(_idUser) && other._reopeningDate.Equals(_reopeningDate);
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
                result = (result*397) ^ _idUser.GetHashCode();
                result = (result*397) ^ _reopeningDate.GetHashCode();
                return result;
            }
        }
    }

    
}
