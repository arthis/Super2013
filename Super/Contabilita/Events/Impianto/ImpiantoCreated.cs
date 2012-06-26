using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Messaging.ValueObjects;

namespace Super.Contabilita.Events.Impianto
{
    public class ImpiantoCreated :  Message ,IEvent
    {
        private readonly Guid _idLotto;

        public Guid Id { get; set; }
        public Intervall Period { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Description { get; private set; }
        public Guid IdLotto
        {
            get { return _idLotto; }
        }

        //for serialization
        public ImpiantoCreated()
        {
            
        }

        public ImpiantoCreated(Guid id, Intervall period, Guid idLotto, DateTime creationDate, string description)
        {
            _idLotto = idLotto;
            Id = id;
            Period = period;
            CreationDate = creationDate;
            Description = description;
        }

        public override string ToDescription()
        {
            return string.Format("L'impianto é stata creata '{0}'.", Description);
        }

        public bool Equals(ImpiantoCreated other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && other.Id.Equals(Id) && Equals(other.Period, Period) && other.CreationDate.Equals(CreationDate) && Equals(other.Description, Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ImpiantoCreated);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = base.GetHashCode();
                result = (result*397) ^ Id.GetHashCode();
                result = (result*397) ^ (Period != null ? Period.GetHashCode() : 0);
                result = (result*397) ^ CreationDate.GetHashCode();
                result = (result*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return result;
            }
        }
    }
}
