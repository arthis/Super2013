using System;
using System.Diagnostics.Contracts;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Commands.AreaIntervento
{
    
    public class CreateAreaIntervento : CommandBase
    {
        
        private readonly Intervall _period;
        private readonly DateTime _creationDate;
        private readonly string _description;
        private readonly Guid _idLotto;
        
        public CreateAreaIntervento()
        {
            
        }
        
        public CreateAreaIntervento(Guid id,  Intervall period, DateTime creationDate, string description, Guid idLotto)
        {
            Contract.Requires<ArgumentNullException>(period==null);
            Contract.Requires<ArgumentOutOfRangeException>(creationDate ==DateTime.MinValue );
            Contract.Requires<ArgumentException>(string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description));
            Contract.Requires<ArgumentNullException>(idLotto== Guid.Empty);


            _version = version;
            _period = period;
            _creationDate = creationDate;
            _description = description;
            _idLotto = idLotto;
            this.Id = id;
            
        }

        public string Description
        {
            get { return _description; }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
        }
        public Intervall Period
        {
            get { return _period; }
        }
        public Guid IdLotto
        {
            get { return _idLotto; }
        }

        public override string ToDescription()
        {
            return string.Format("Creiamo il area Intervento '{0}'.", Description);
        }

        public bool Equals(CreateAreaIntervento other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other._period, _period) && other._creationDate.Equals(_creationDate) && Equals(other._description, _description) && other._idLotto.Equals(_idLotto);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as CreateAreaIntervento);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ (_period != null ? _period.GetHashCode() : 0);
                result = (result*397) ^ _creationDate.GetHashCode();
                result = (result*397) ^ (_description != null ? _description.GetHashCode() : 0);
                result = (result*397) ^ _idLotto.GetHashCode();
                return result;
            }
        }
    }
}
